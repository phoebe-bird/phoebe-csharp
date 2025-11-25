using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAdjacentService
{
    IAdjacentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of countries or regions that share a border with this one. ####
    /// Notes Only subnational2 codes in the United States, New Zealand, or Mexico
    /// are currently supported
    /// </summary>
    Task<List<AdjacentListResponse>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of countries or regions that share a border with this one. ####
    /// Notes Only subnational2 codes in the United States, New Zealand, or Mexico
    /// are currently supported
    /// </summary>
    Task<List<AdjacentListResponse>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
