using System;
using Phoebe.Core;
using Phoebe.Services.Data;

namespace Phoebe.Services;

/// <inheritdoc/>
public sealed class DataService : IDataService
{
    readonly Lazy<IDataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IDataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataService(this._client.WithOptions(modifier));
    }

    public DataService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataServiceWithRawResponse(client.WithRawResponse));
        _observations = new(() => new ObservationService(client));
    }

    readonly Lazy<IObservationService> _observations;
    public IObservationService Observations
    {
        get { return _observations.Value; }
    }
}

/// <inheritdoc/>
public sealed class DataServiceWithRawResponse : IDataServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _observations = new(() => new ObservationServiceWithRawResponse(client));
    }

    readonly Lazy<IObservationServiceWithRawResponse> _observations;
    public IObservationServiceWithRawResponse Observations
    {
        get { return _observations.Value; }
    }
}
