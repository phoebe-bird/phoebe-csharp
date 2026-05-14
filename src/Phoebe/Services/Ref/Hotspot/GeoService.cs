using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot.Geo;

namespace Phoebe.Services.Ref.Hotspot;

/// <inheritdoc/>
public sealed class GeoService : IGeoService
{
    readonly Lazy<IGeoServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGeoServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IGeoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoService(this._client.WithOptions(modifier));
    }

    public GeoService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GeoServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<GeoRetrieveResponse>> Retrieve(
        GeoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GeoServiceWithRawResponse : IGeoServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGeoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GeoServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<GeoRetrieveResponse>>> Retrieve(
        GeoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeoRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var geos = await response
                    .Deserialize<List<GeoRetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in geos)
                    {
                        item.Validate();
                    }
                }
                return geos;
            }
        );
    }
}
