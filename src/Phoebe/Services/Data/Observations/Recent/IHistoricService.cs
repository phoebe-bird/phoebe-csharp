using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Services.Data.Observations.Recent;

/// <summary>
/// The data/obs end-points are used to fetch observations submitted to eBird in
/// checklists. There are two categories of end-point: 1. Fetch observations for a
/// specific country, region or location. 2. Fetch observations for nearby locations
/// - up to a distance of 50km. Each end-point supports optional query parameters
/// which allow you to filter the list of observations returned.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IHistoricService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHistoricServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoricService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a list of all taxa seen in a country, region or location on a specific date,
    /// with the specific observations determined by the "rank" parameter (defaults to
    /// latest observation on the date). #### Notes Responses may be cached for 30
    /// minutes
    /// </summary>
    Task<List<Observation>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(HistoricListParams, CancellationToken)"/>
    Task<List<Observation>> List(
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHistoricService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHistoricServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoricServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /data/obs/{regionCode}/historic/{y}/{m}/{d}</c>, but is otherwise the
    /// same as <see cref="IHistoricService.List(HistoricListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(HistoricListParams, CancellationToken)"/>
    Task<HttpResponse<List<Observation>>> List(
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );
}
