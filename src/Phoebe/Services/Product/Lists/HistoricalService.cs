using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Services.Product.Lists;

/// <inheritdoc />
public sealed class HistoricalService : IHistoricalService
{
    /// <inheritdoc/>
    public IHistoricalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoricalService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public HistoricalService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<HistoricalRetrieveResponse>> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var historicals = await response
            .Deserialize<List<HistoricalRetrieveResponse>>(cancellationToken)
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

    /// <inheritdoc/>
    public async Task<List<HistoricalRetrieveResponse>> Retrieve(
        long d,
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
