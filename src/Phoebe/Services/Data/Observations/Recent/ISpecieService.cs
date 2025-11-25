using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Species;

namespace Phoebe.Services.Data.Observations.Recent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpecieService
{
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
        string speciesCode,
        SpecieRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
