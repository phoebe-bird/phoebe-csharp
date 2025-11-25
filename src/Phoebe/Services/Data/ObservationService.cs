using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations;

namespace Phoebe.Services.Data;

public sealed class ObservationService : IObservationService
{
    public IObservationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ObservationService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public ObservationService(IPhoebeClient client)
    {
        _client = client;
        _recent = new(() => new RecentService(client));
        _geo = new(() => new GeoService(client));
        _nearest = new(() => new NearestService(client));
    }

    readonly Lazy<IRecentService> _recent;
    public IRecentService Recent
    {
        get { return _recent.Value; }
    }

    readonly Lazy<IGeoService> _geo;
    public IGeoService Geo
    {
        get { return _geo.Value; }
    }

    readonly Lazy<INearestService> _nearest;
    public INearestService Nearest
    {
        get { return _nearest.Value; }
    }
}
