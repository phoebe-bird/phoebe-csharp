using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Nearest.GeoSpecies;

namespace Phoebe.Services.Data.Observations.Nearest;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGeoSpecieService
{
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
