using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Services.Data.Observations.Recent;

public sealed class HistoricService : IHistoricService
{
    public IHistoricService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoricService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public HistoricService(IPhoebeClient client)
    {
        _client = client;
    }

    public async Task<List<Observation>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.D == null)
        {
            throw new PhoebeInvalidDataException("'parameters.D' cannot be null");
        }

        HttpRequest<HistoricListParams> request = new()
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
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.List(parameters with { D = d }, cancellationToken);
    }
}
