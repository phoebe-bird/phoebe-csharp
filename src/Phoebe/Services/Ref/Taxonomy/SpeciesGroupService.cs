using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Services.Ref.Taxonomy;

/// <inheritdoc/>
public sealed class SpeciesGroupService : ISpeciesGroupService
{
    readonly Lazy<ISpeciesGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeciesGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ISpeciesGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeciesGroupService(this._client.WithOptions(modifier));
    }

    public SpeciesGroupService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SpeciesGroupServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<List<SpeciesGroupListResponse>> List(
        SpeciesGroupListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<SpeciesGroupListResponse>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SpeciesGrouping = speciesGrouping }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpeciesGroupServiceWithRawResponse : ISpeciesGroupServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeciesGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SpeciesGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeciesGroupServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<SpeciesGroupListResponse>>> List(
        SpeciesGroupListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpeciesGrouping == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SpeciesGrouping' cannot be null");
        }

        HttpRequest<SpeciesGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var speciesGroups = await response
                    .Deserialize<List<SpeciesGroupListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in speciesGroups)
                    {
                        item.Validate();
                    }
                }
                return speciesGroups;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<SpeciesGroupListResponse>>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SpeciesGrouping = speciesGrouping }, cancellationToken);
    }
}
