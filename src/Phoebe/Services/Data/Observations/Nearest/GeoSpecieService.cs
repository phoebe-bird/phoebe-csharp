using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Nearest.GeoSpecies;

namespace Phoebe.Services.Data.Observations.Nearest;

/// <inheritdoc/>
public sealed class GeoSpecieService : IGeoSpecieService
{
    readonly Lazy<IGeoSpecieServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGeoSpecieServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IGeoSpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoSpecieService(this._client.WithOptions(modifier));
    }

    public GeoSpecieService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GeoSpecieServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<Observation>> List(
        string speciesCode,
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GeoSpecieServiceWithRawResponse : IGeoSpecieServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGeoSpecieServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeoSpecieServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GeoSpecieServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpeciesCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SpeciesCode' cannot be null");
        }

        HttpRequest<GeoSpecieListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var observations = await response
                    .Deserialize<List<Observation>>(token)
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
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<Observation>>> List(
        string speciesCode,
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}
