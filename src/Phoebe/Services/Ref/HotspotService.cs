using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Hotspot;
using Phoebe.Services.Ref.Hotspot;

namespace Phoebe.Services.Ref;

public sealed class HotspotService : IHotspotService
{
    public IHotspotService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HotspotService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public HotspotService(IPhoebeClient client)
    {
        _client = client;
        _geo = new(() => new GeoService(client));
        _info = new(() => new InfoService(client));
    }

    readonly Lazy<IGeoService> _geo;
    public IGeoService Geo
    {
        get { return _geo.Value; }
    }

    readonly Lazy<IInfoService> _info;
    public IInfoService Info
    {
        get { return _info.Value; }
    }

    public async Task<List<HotspotListResponse>> List(
        HotspotListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<HotspotListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var hotspots = await response
            .Deserialize<List<HotspotListResponse>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in hotspots)
            {
                item.Validate();
            }
        }
        return hotspots;
    }

    public async Task<List<HotspotListResponse>> List(
        string regionCode,
        HotspotListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
