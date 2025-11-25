using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Recent.Notable;

namespace Phoebe.Services.Data.Observations.Recent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INotableService
{
    INotableService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of recent, notable observations (up to 30 days ago) of birds
    /// seen in a country, region or location. Notable observations can be for locally
    /// or nationally rare species or are otherwise unusual, e.g. over-wintering birds
    /// in a species which is normally only a summer visitor.
    /// </summary>
    Task<List<Observation>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of recent, notable observations (up to 30 days ago) of birds
    /// seen in a country, region or location. Notable observations can be for locally
    /// or nationally rare species or are otherwise unusual, e.g. over-wintering birds
    /// in a species which is normally only a summer visitor.
    /// </summary>
    Task<List<Observation>> List(
        string regionCode,
        NotableListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
