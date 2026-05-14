using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.SpeciesList;

namespace Phoebe.Services.Product;

/// <inheritdoc/>
public sealed class SpeciesListService : ISpeciesListService
{
    readonly Lazy<ISpeciesListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeciesListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ISpeciesListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeciesListService(this._client.WithOptions(modifier));
    }

    public SpeciesListService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpeciesListServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<string>> List(
        SpeciesListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<string>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpeciesListServiceWithRawResponse : ISpeciesListServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeciesListServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SpeciesListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeciesListServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<string>>> List(
        SpeciesListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<SpeciesListListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<string>>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<string>>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
