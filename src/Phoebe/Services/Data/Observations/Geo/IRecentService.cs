using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent;
using Phoebe.Services.Data.Observations.Geo.Recent;

namespace Phoebe.Services.Data.Observations.Geo;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRecentService
{
    global::Phoebe.Services.Data.Observations.Geo.IRecentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    ISpecieService Species { get; }

    INotableService Notable { get; }

    /// <summary>
    /// Get the list of recent observations (up to 30 days ago) of birds seen at locations
    /// within a radius of up to 50 kilometers, from a given set of coordinates.
    /// Results include only the most recent observation for each species in the
    /// region specified.
    /// </summary>
    Task<List<Observation>> List(
        RecentListParams parameters,
        CancellationToken cancellationToken = default
    );
}
