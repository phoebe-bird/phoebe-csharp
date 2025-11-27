using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Notable;

namespace Phoebe.Services.Data.Observations.Recent;

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
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        string regionCode,
        NotableListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
