using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Stats;

namespace Phoebe.Services.Product;

/// <inheritdoc/>
public sealed class StatService : IStatService
{
    readonly Lazy<IStatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStatServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IStatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StatService(this._client.WithOptions(modifier));
    }

    public StatService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StatServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<StatRetrieveResponse> Retrieve(
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StatRetrieveResponse> Retrieve(
        long d,
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class StatServiceWithRawResponse : IStatServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StatServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StatRetrieveResponse>> Retrieve(
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.D == null)
        {
            throw new PhoebeInvalidDataException("'parameters.D' cannot be null");
        }

        HttpRequest<StatRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var stat = await response
                    .Deserialize<StatRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    stat.Validate();
                }
                return stat;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StatRetrieveResponse>> Retrieve(
        long d,
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
