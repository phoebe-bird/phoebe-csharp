using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Services.Product.Lists;

/// <inheritdoc/>
public sealed class HistoricalService : IHistoricalService
{
    readonly Lazy<IHistoricalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHistoricalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IHistoricalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoricalService(this._client.WithOptions(modifier));
    }

    public HistoricalService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HistoricalServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<HistoricalRetrieveResponse>> Retrieve(
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<HistoricalRetrieveResponse>> Retrieve(
        long d,
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class HistoricalServiceWithRawResponse : IHistoricalServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHistoricalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new HistoricalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HistoricalServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<HistoricalRetrieveResponse>>> Retrieve(
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.D == null)
        {
            throw new PhoebeInvalidDataException("'parameters.D' cannot be null");
        }

        HttpRequest<HistoricalRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var historicals = await response
                    .Deserialize<List<HistoricalRetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in historicals)
                    {
                        item.Validate();
                    }
                }
                return historicals;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<HistoricalRetrieveResponse>>> Retrieve(
        long d,
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
