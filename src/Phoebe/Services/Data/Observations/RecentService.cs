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

/// <inheritdoc/>
public sealed class RecentService : IRecentService
{
    readonly Lazy<IRecentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IRecentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RecentService(this._client.WithOptions(modifier));
    }

    public RecentService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RecentServiceWithRawResponse(client.WithRawResponse));
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

    /// <inheritdoc/>
    public async Task<List<Observation>> List(
        RecentListParams parameters,
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
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RecentServiceWithRawResponse : IRecentServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RecentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecentServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _notable = new(() => new NotableServiceWithRawResponse(client));
        _species = new(() => new SpecieServiceWithRawResponse(client));
        _historic = new(() => new HistoricServiceWithRawResponse(client));
    }

    readonly Lazy<INotableServiceWithRawResponse> _notable;
    public INotableServiceWithRawResponse Notable
    {
        get { return _notable.Value; }
    }

    readonly Lazy<ISpecieServiceWithRawResponse> _species;
    public ISpecieServiceWithRawResponse Species
    {
        get { return _species.Value; }
    }

    readonly Lazy<IHistoricServiceWithRawResponse> _historic;
    public IHistoricServiceWithRawResponse Historic
    {
        get { return _historic.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
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
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
