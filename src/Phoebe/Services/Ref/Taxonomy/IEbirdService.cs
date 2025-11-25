using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Ebird;

namespace Phoebe.Services.Ref.Taxonomy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEbirdService
{
    IEbirdService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the taxonomy used by eBird. #### Notes Each entry in the taxonomy contains
    /// a species code for example, barswa for Barn Swallow. You can download the
    /// taxonomy for selected species using the *species* query parameter with a
    /// comma separating each code. Otherwise the full taxonomy is downloaded.
    /// </summary>
    Task<List<EbirdRetrieveResponse>> Retrieve(
        EbirdRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
