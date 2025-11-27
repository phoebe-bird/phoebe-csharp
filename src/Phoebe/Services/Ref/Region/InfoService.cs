using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Services.Ref.Region;

/// <inheritdoc />
public sealed class InfoService : IInfoService
{
    /// <inheritdoc/>
    public IInfoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InfoService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public InfoService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<InfoRetrieveResponse> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<InfoRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var info = await response
            .Deserialize<InfoRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            info.Validate();
        }
        return info;
    }

    /// <inheritdoc/>
    public async Task<InfoRetrieveResponse> Retrieve(
        string regionCode,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
