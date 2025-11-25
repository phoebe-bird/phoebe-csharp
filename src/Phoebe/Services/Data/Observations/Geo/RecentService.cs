using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent;
using Phoebe.Services.Data.Observations.Geo.Recent;

namespace Phoebe.Services.Data.Observations.Geo;

public sealed class RecentService : global::Phoebe.Services.Data.Observations.Geo.IRecentService
{
    public global::Phoebe.Services.Data.Observations.Geo.IRecentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Phoebe.Services.Data.Observations.Geo.RecentService(
            this._client.WithOptions(modifier)
        );
    }

    readonly IPhoebeClient _client;

    public RecentService(IPhoebeClient client)
    {
        _client = client;
        _species = new(() => new SpecieService(client));
        _notable = new(() => new NotableService(client));
    }

    readonly Lazy<ISpecieService> _species;
    public ISpecieService Species
    {
        get { return _species.Value; }
    }

    readonly Lazy<INotableService> _notable;
    public INotableService Notable
    {
        get { return _notable.Value; }
    }

    public async Task<List<Observation>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
