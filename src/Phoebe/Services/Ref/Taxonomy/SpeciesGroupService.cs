using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Services.Ref.Taxonomy;

public sealed class SpeciesGroupService : ISpeciesGroupService
{
    public ISpeciesGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeciesGroupService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public SpeciesGroupService(IPhoebeClient client)
    {
        _client = client;
    }

    public async Task<List<SpeciesGroupListResponse>> List(
        SpeciesGroupListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpeciesGrouping == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SpeciesGrouping' cannot be null");
        }

        HttpRequest<SpeciesGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var speciesGroups = await response
            .Deserialize<List<SpeciesGroupListResponse>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in speciesGroups)
            {
                item.Validate();
            }
        }
        return speciesGroups;
    }

    public async Task<List<SpeciesGroupListResponse>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(
            parameters with
            {
                SpeciesGrouping = speciesGrouping,
            },
            cancellationToken
        );
    }
}
