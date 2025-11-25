using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Locales;

namespace Phoebe.Services.Ref.Taxonomy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILocaleService
{
    ILocaleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the list of supported locale codes and names for species common names,
    /// with the last time they were updated. Use the accept-language header to get
    /// translated language names when available.
    ///
    /// <para>NOTE: The locale codes and names are stable but the other fields in
    /// this result are not yet finalized and should be used with caution.</para>
    /// </summary>
    Task<List<LocaleListResponse>> List(
        LocaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
