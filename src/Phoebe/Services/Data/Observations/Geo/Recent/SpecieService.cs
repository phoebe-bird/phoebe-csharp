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

/// <inheritdoc/>
public sealed class SpecieService : ISpecieService
{
    readonly Lazy<ISpecieServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpecieServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ISpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpecieService(this._client.WithOptions(modifier));
    }

    public SpecieService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpecieServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        SpecieListParams parameters,
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
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpecieServiceWithRawResponse : ISpecieServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpecieServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpecieServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpecieServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
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
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}
