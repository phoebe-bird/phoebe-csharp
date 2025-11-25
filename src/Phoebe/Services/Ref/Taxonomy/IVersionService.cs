using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Versions;

namespace Phoebe.Services.Ref.Taxonomy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVersionService
{
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a list of all versions of the taxonomy, with a flag indicating which
    /// is the latest.
    /// </summary>
    Task<List<VersionListResponse>> List(
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
