using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Notable;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

/// <inheritdoc/>
public sealed class NotableService : INotableService
{
    readonly Lazy<INotableServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotableServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public INotableService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotableService(this._client.WithOptions(modifier));
    }

    public NotableService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NotableServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NotableServiceWithRawResponse : INotableServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotableServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotableServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotableServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NotableListParams> request = new()
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
}
