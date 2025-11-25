using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.SpeciesList;

namespace Phoebe.Services.Product;

public sealed class SpeciesListService : ISpeciesListService
{
    public ISpeciesListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeciesListService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public SpeciesListService(IPhoebeClient client)
    {
        _client = client;
    }

    public async Task<List<string>> List(
        SpeciesListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<SpeciesListListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<List<string>>(cancellationToken).ConfigureAwait(false);
    }

    public async Task<List<string>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
