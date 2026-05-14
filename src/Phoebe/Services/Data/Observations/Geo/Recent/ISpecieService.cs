using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Species;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

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
public interface ISpecieService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpecieServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get all observations of a species, seen up to 30 days ago, at any location
    /// within a radius of up to 50 kilometers, from a given set of coordinates. Results
    /// include only the most recent observation from each location in the region
    /// specified.
    ///
    /// <para>#### URL parameters</para>
    ///
    /// <para>| Name | Description | | ---------- | ----------- | | speciesCode | The
    /// eBird species code. | #### Notes The species code is typically a 6-letter code,
    /// e.g. horlar for Horned Lark. You can get complete set of species code from the
    /// GET eBird Taxonomy end-point.</para>
    /// </summary>
    Task<List<Observation>> List(
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SpecieListParams, CancellationToken)"/>
    Task<List<Observation>> List(
        string speciesCode,
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpecieService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpecieServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpecieServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /data/obs/geo/recent/{speciesCode}</c>, but is otherwise the
    /// same as <see cref="ISpecieService.List(SpecieListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> List(
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SpecieListParams, CancellationToken)"/>
    Task<HttpResponse<List<Observation>>> List(
        string speciesCode,
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );
}
