using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Species;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

/// <inheritdoc />
public sealed class SpecieService : ISpecieService
{
    /// <inheritdoc/>
    public ISpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpecieService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public SpecieService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpeciesCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SpeciesCode' cannot be null");
        }

        HttpRequest<SpecieListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var observations = await response
            .Deserialize<List<Observation>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in observations)
            {
                item.Validate();
            }
        }
        return observations;
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        string speciesCode,
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}
