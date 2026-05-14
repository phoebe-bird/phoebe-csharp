using System;
using Phoebe.Core;
using Geo = Phoebe.Services.Data.Observations.Geo;

namespace Phoebe.Services.Data.Observations;

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
        _recent = new(() => new Geo::RecentService(client));
    }

    readonly Lazy<Geo::IRecentService> _recent;
    public Geo::IRecentService Recent
    {
        get { return _recent.Value; }
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

        _recent = new(() => new Geo::RecentServiceWithRawResponse(client));
    }

    readonly Lazy<Geo::IRecentServiceWithRawResponse> _recent;
    public Geo::IRecentServiceWithRawResponse Recent
    {
        get { return _recent.Value; }
    }
}
