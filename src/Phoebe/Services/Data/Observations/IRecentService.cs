using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent;
using Phoebe.Services.Data.Observations.Recent;

namespace Phoebe.Services.Data.Observations;

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
public interface IRecentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    INotableService Notable { get; }

    ISpecieService Species { get; }

    IHistoricService Historic { get; }

    /// <summary>
    /// Get the list of recent observations (up to 30 days ago) of birds seen in a
    /// country, state, county, or location. Results include only the most recent
    /// observation for each species in the region specified.
    /// </summary>
    Task<List<Observation>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RecentListParams, CancellationToken)"/>
    Task<List<Observation>> List(
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRecentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    INotableServiceWithRawResponse Notable { get; }

    ISpecieServiceWithRawResponse Species { get; }

    IHistoricServiceWithRawResponse Historic { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /data/obs/{regionCode}/recent`, but is otherwise the
    /// same as <see cref="IRecentService.List(RecentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RecentListParams, CancellationToken)"/>
    Task<HttpResponse<List<Observation>>> List(
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
