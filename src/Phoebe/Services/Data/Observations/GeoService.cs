using System;
using Phoebe.Core;
using Geo = Phoebe.Services.Data.Observations.Geo;

namespace Phoebe.Services.Data.Observations;

public sealed class GeoService : IGeoService
{
    public IGeoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public GeoService(IPhoebeClient client)
    {
        _client = client;
        _recent = new(() => new Geo::RecentService(client));
    }

    readonly Lazy<Geo::IRecentService> _recent;
    public Geo::IRecentService Recent
    {
        get { return _recent.Value; }
    }
}
