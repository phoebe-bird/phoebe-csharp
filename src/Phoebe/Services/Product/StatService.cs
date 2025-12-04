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
    /// <inheritdoc/>
    public IStatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StatService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public StatService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<StatRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var stat = await response
            .Deserialize<StatRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            stat.Validate();
        }
        return stat;
    }

    /// <inheritdoc/>
    public async Task<StatRetrieveResponse> Retrieve(
        long d,
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { D = d }, cancellationToken);
    }
}
