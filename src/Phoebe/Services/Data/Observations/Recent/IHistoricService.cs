using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Services.Data.Observations.Recent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHistoricService
{
    IHistoricService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a list of all taxa seen in a country, region or location on a specific
    /// date, with the specific observations determined by the "rank" parameter (defaults
    /// to latest observation on the date). #### Notes Responses may be cached for
    /// 30 minutes
    /// </summary>
    Task<List<Observation>> List(
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of all taxa seen in a country, region or location on a specific
    /// date, with the specific observations determined by the "rank" parameter (defaults
    /// to latest observation on the date). #### Notes Responses may be cached for
    /// 30 minutes
    /// </summary>
    Task<List<Observation>> List(
        long d,
        HistoricListParams parameters,
        CancellationToken cancellationToken = default
    );
}
