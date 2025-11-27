using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot.Geo;

namespace Phoebe.Services.Ref.Hotspot;

/// <inheritdoc />
public sealed class GeoService : IGeoService
{
    /// <inheritdoc/>
    public IGeoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public GeoService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<GeoRetrieveResponse>> Retrieve(
        GeoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeoRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var geos = await response
            .Deserialize<List<GeoRetrieveResponse>>(cancellationToken)
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
}
