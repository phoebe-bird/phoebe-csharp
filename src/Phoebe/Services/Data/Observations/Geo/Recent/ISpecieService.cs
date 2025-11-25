using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Species;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpecieService
{
    ISpecieService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get all observations of a species, seen up to 30 days ago, at any location
    /// within a radius of up to 50 kilometers, from a given set of coordinates. Results
    /// include only the most recent observation from each location in the region specified.
    ///
    /// <para>#### URL parameters</para>
    ///
    /// <para>| Name | Description | | ---------- | ----------- | | speciesCode |
    /// The eBird species code. | #### Notes The species code is typically a 6-letter
    /// code, e.g. horlar for Horned Lark. You can get complete set of species code
    /// from the GET eBird Taxonomy end-point.</para>
    /// </summary>
    Task<List<Observation>> List(
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all observations of a species, seen up to 30 days ago, at any location
    /// within a radius of up to 50 kilometers, from a given set of coordinates. Results
    /// include only the most recent observation from each location in the region specified.
    ///
    /// <para>#### URL parameters</para>
    ///
    /// <para>| Name | Description | | ---------- | ----------- | | speciesCode |
    /// The eBird species code. | #### Notes The species code is typically a 6-letter
    /// code, e.g. horlar for Horned Lark. You can get complete set of species code
    /// from the GET eBird Taxonomy end-point.</para>
    /// </summary>
    Task<List<Observation>> List(
        string speciesCode,
        SpecieListParams parameters,
        CancellationToken cancellationToken = default
    );
}
