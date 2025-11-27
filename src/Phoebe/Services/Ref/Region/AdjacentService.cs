using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Services.Ref.Region;

/// <inheritdoc />
public sealed class AdjacentService : IAdjacentService
{
    /// <inheritdoc/>
    public IAdjacentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AdjacentService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public AdjacentService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<AdjacentListResponse>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<AdjacentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var adjacents = await response
            .Deserialize<List<AdjacentListResponse>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in adjacents)
            {
                item.Validate();
            }
        }
        return adjacents;
    }

    /// <inheritdoc/>
    public async Task<List<AdjacentListResponse>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
