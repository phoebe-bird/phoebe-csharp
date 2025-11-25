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
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRecentService
{
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

    /// <summary>
    /// Get the list of recent observations (up to 30 days ago) of birds seen in a
    /// country, state, county, or location. Results include only the most recent
    /// observation for each species in the region specified.
    /// </summary>
    Task<List<Observation>> List(
        string regionCode,
        RecentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
