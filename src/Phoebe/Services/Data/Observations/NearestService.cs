using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations.Nearest;

namespace Phoebe.Services.Data.Observations;

/// <inheritdoc/>
public sealed class NearestService : INearestService
{
    /// <inheritdoc/>
    public INearestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NearestService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public NearestService(IPhoebeClient client)
    {
        _client = client;
        _geoSpecies = new(() => new GeoSpecieService(client));
    }

    readonly Lazy<IGeoSpecieService> _geoSpecies;
    public IGeoSpecieService GeoSpecies
    {
        get { return _geoSpecies.Value; }
    }
}
