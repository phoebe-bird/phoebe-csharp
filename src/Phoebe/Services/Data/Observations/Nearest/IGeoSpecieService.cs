using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Nearest.GeoSpecies;

namespace Phoebe.Services.Data.Observations.Nearest;

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
public interface IGeoSpecieService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGeoSpecieServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeoSpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Find the nearest locations where a species has been seen recently. #### Notes
    /// The species code is typically a 6-letter code, e.g. barswa for Barn Swallow.
    /// You can get complete set of species code from the GET eBird Taxonomy end-point.
    /// </summary>
    Task<List<Observation>> List(
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GeoSpecieListParams, CancellationToken)"/>
    Task<List<Observation>> List(
        string speciesCode,
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGeoSpecieService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGeoSpecieServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeoSpecieServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /data/nearest/geo/recent/{speciesCode}`, but is otherwise the
    /// same as <see cref="IGeoSpecieService.List(GeoSpecieListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> List(
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GeoSpecieListParams, CancellationToken)"/>
    Task<HttpResponse<List<Observation>>> List(
        string speciesCode,
        GeoSpecieListParams parameters,
        CancellationToken cancellationToken = default
    );
}
