using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Services.Ref.Region;

/// <inheritdoc/>
public sealed class AdjacentService : IAdjacentService
{
    readonly Lazy<IAdjacentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAdjacentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IAdjacentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AdjacentService(this._client.WithOptions(modifier));
    }

    public AdjacentService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AdjacentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<AdjacentListResponse>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<AdjacentListResponse>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AdjacentServiceWithRawResponse : IAdjacentServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAdjacentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AdjacentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AdjacentServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AdjacentListResponse>>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<AdjacentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var adjacents = await response
                    .Deserialize<List<AdjacentListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in adjacents)
                    {
                        item.Validate();
                    }
                }
                return adjacents;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<AdjacentListResponse>>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
