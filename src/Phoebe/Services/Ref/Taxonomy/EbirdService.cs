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
    /// <inheritdoc/>
    public IEbirdService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EbirdService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public EbirdService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<EbirdRetrieveResponse>> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var ebirds = await response
            .Deserialize<List<EbirdRetrieveResponse>>(cancellationToken)
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
}
