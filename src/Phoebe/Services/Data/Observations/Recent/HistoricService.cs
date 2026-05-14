using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Services.Data.Observations.Recent;

/// <inheritdoc/>
public sealed class HistoricService : IHistoricService
{
    readonly Lazy<IHistoricServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHistoricServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IHistoricService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoricService(this._client.WithOptions(modifier));
    }

    public HistoricService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HistoricServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<Observation>> List(
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { D = d }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class HistoricServiceWithRawResponse : IHistoricServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHistoricServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoricServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HistoricServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.D == null)
        {
            throw new PhoebeInvalidDataException("'parameters.D' cannot be null");
        }

        HttpRequest<HistoricListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var observations = await response
                    .Deserialize<List<Observation>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in observations)
                    {
                        item.Validate();
                    }
                }
                return observations;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<Observation>>> List(
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { D = d }, cancellationToken);
    }
}
