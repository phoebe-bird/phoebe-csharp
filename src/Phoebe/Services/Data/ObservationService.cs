using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations;

namespace Phoebe.Services.Data;

/// <inheritdoc/>
public sealed class ObservationService : IObservationService
{
    readonly Lazy<IObservationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IObservationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IObservationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ObservationService(this._client.WithOptions(modifier));
    }

    public ObservationService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ObservationServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class ObservationServiceWithRawResponse : IObservationServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IObservationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ObservationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ObservationServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _recent = new(() => new RecentServiceWithRawResponse(client));
        _geo = new(() => new GeoServiceWithRawResponse(client));
        _nearest = new(() => new NearestServiceWithRawResponse(client));
    }

    readonly Lazy<IRecentServiceWithRawResponse> _recent;
    public IRecentServiceWithRawResponse Recent
    {
        get { return _recent.Value; }
    }

    readonly Lazy<IGeoServiceWithRawResponse> _geo;
    public IGeoServiceWithRawResponse Geo
    {
        get { return _geo.Value; }
    }

    readonly Lazy<INearestServiceWithRawResponse> _nearest;
    public INearestServiceWithRawResponse Nearest
    {
        get { return _nearest.Value; }
    }
}
