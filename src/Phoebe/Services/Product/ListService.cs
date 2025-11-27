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

/// <inheritdoc />
public sealed class ListService : IListService
{
    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public ListService(IPhoebeClient client)
    {
        _client = client;
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
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var lists = await response
            .Deserialize<List<ListRetrieveResponse>>(cancellationToken)
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

    /// <inheritdoc/>
    public async Task<List<ListRetrieveResponse>> Retrieve(
        string regionCode,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
