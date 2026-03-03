using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Species;

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
    /// Get the recent observations, up to 30 days ago, of a particular species in
    /// a country, region or location. Results include only the most recent observation
    /// from each location in the region specified. #### Notes
    ///
    /// <para>The species code is typically a 6-letter code, e.g. cangoo for Canada
    /// Goose. You can get complete set of species code from the GET eBird Taxonomy end-point.</para>
    ///
    /// <para>When using the *r* query parameter set the *regionCode* URL parameter
    /// to an empty string.</para>
    /// </summary>
    Task<List<Observation>> Retrieve(
        SpecieRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SpecieRetrieveParams, CancellationToken)"/>
    Task<List<Observation>> Retrieve(
        string speciesCode,
        SpecieRetrieveParams parameters,
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
    /// Returns a raw HTTP response for `get /data/obs/{regionCode}/recent/{speciesCode}`, but is otherwise the
    /// same as <see cref="ISpecieService.Retrieve(SpecieRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> Retrieve(
        SpecieRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SpecieRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<Observation>>> Retrieve(
        string speciesCode,
        SpecieRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
