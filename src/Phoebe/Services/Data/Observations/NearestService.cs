using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations.Nearest;

namespace Phoebe.Services.Data.Observations;

/// <inheritdoc/>
public sealed class NearestService : INearestService
{
    readonly Lazy<INearestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INearestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public INearestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NearestService(this._client.WithOptions(modifier));
    }

    public NearestService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NearestServiceWithRawResponse(client.WithRawResponse));
        _geoSpecies = new(() => new GeoSpecieService(client));
    }

    readonly Lazy<IGeoSpecieService> _geoSpecies;
    public IGeoSpecieService GeoSpecies
    {
        get { return _geoSpecies.Value; }
    }
}

/// <inheritdoc/>
public sealed class NearestServiceWithRawResponse : INearestServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public INearestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NearestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NearestServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _geoSpecies = new(() => new GeoSpecieServiceWithRawResponse(client));
    }

    readonly Lazy<IGeoSpecieServiceWithRawResponse> _geoSpecies;
    public IGeoSpecieServiceWithRawResponse GeoSpecies
    {
        get { return _geoSpecies.Value; }
    }
}
