using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent;
using Phoebe.Services.Data.Observations.Recent;

namespace Phoebe.Services.Data.Observations;

public sealed class RecentService : IRecentService
{
    public IRecentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RecentService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public RecentService(IPhoebeClient client)
    {
        _client = client;
        _notable = new(() => new NotableService(client));
        _species = new(() => new SpecieService(client));
        _historic = new(() => new HistoricService(client));
    }

    readonly Lazy<INotableService> _notable;
    public INotableService Notable
    {
        get { return _notable.Value; }
    }

    readonly Lazy<ISpecieService> _species;
    public ISpecieService Species
    {
        get { return _species.Value; }
    }

    readonly Lazy<IHistoricService> _historic;
    public IHistoricService Historic
    {
        get { return _historic.Value; }
    }

    public async Task<List<Observation>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<RecentListParams> request = new()
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

    public async Task<List<Observation>> List(
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
