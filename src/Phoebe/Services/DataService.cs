using System;
using Phoebe.Core;
using Phoebe.Services.Data;

namespace Phoebe.Services;

/// <inheritdoc />
public sealed class DataService : IDataService
{
    /// <inheritdoc/>
    public IDataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public DataService(IPhoebeClient client)
    {
        _client = client;
        _observations = new(() => new ObservationService(client));
    }

    readonly Lazy<IObservationService> _observations;
    public IObservationService Observations
    {
        get { return _observations.Value; }
    }
}
