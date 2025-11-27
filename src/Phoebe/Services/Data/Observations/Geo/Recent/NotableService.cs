using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Notable;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

/// <inheritdoc />
public sealed class NotableService : INotableService
{
    /// <inheritdoc/>
    public INotableService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotableService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public NotableService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NotableListParams> request = new()
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
