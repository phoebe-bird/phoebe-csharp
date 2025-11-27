using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Services.Product;

/// <inheritdoc />
public sealed class Top100Service : ITop100Service
{
    /// <inheritdoc/>
    public ITop100Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new Top100Service(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public Top100Service(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<Top100RetrieveResponse>> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var top100s = await response
            .Deserialize<List<Top100RetrieveResponse>>(cancellationToken)
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

    /// <inheritdoc/>
    public async Task<List<Top100RetrieveResponse>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
