using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Lists;
using Phoebe.Services.Product.Lists;

namespace Phoebe.Services.Product;

/// <inheritdoc/>
public sealed class ListService : IListService
{
    readonly Lazy<IListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    public ListService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ListServiceWithRawResponse(client.WithRawResponse));
        _historical = new(() => new HistoricalService(client));
    }

    readonly Lazy<IHistoricalService> _historical;
    public IHistoricalService Historical
    {
        get { return _historical.Value; }
    }

    /// <inheritdoc/>
    public async Task<List<ListRetrieveResponse>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<ListRetrieveResponse>> Retrieve(
        string regionCode,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ListServiceWithRawResponse : IListServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ListServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _historical = new(() => new HistoricalServiceWithRawResponse(client));
    }

    readonly Lazy<IHistoricalServiceWithRawResponse> _historical;
    public IHistoricalServiceWithRawResponse Historical
    {
        get { return _historical.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ListRetrieveResponse>>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lists = await response
                    .Deserialize<List<ListRetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in lists)
                    {
                        item.Validate();
                    }
                }
                return lists;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<ListRetrieveResponse>>> Retrieve(
        string regionCode,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
