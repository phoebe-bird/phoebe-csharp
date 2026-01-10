using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Ebird;

namespace Phoebe.Services.Ref.Taxonomy;

/// <inheritdoc/>
public sealed class EbirdService : IEbirdService
{
    readonly Lazy<IEbirdServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEbirdServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IEbirdService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EbirdService(this._client.WithOptions(modifier));
    }

    public EbirdService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EbirdServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<EbirdRetrieveResponse>> Retrieve(
        EbirdRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EbirdServiceWithRawResponse : IEbirdServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEbirdServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EbirdServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EbirdServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<EbirdRetrieveResponse>>> Retrieve(
        EbirdRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EbirdRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ebirds = await response
                    .Deserialize<List<EbirdRetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in ebirds)
                    {
                        item.Validate();
                    }
                }
                return ebirds;
            }
        );
    }
}
