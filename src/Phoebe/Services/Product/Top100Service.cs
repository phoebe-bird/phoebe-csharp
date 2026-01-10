using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Services.Product;

/// <inheritdoc/>
public sealed class Top100Service : ITop100Service
{
    readonly Lazy<ITop100ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITop100ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ITop100Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new Top100Service(this._client.WithOptions(modifier));
    }

    public Top100Service(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new Top100ServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Top100RetrieveResponse>> Retrieve(
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<Top100RetrieveResponse>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class Top100ServiceWithRawResponse : ITop100ServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITop100ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new Top100ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public Top100ServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Top100RetrieveResponse>>> Retrieve(
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.D == null)
        {
            throw new PhoebeInvalidDataException("'parameters.D' cannot be null");
        }

        HttpRequest<Top100RetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var top100s = await response
                    .Deserialize<List<Top100RetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in top100s)
                    {
                        item.Validate();
                    }
                }
                return top100s;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<Top100RetrieveResponse>>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
