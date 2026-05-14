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

        _species = new(() => new SpecieServiceWithRawResponse(client));
        _notable = new(() => new NotableServiceWithRawResponse(client));
    }

    readonly Lazy<ISpecieServiceWithRawResponse> _species;
    public ISpecieServiceWithRawResponse Species
    {
        get { return _species.Value; }
    }

    readonly Lazy<INotableServiceWithRawResponse> _notable;
    public INotableServiceWithRawResponse Notable
    {
        get { return _notable.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Observation>>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
