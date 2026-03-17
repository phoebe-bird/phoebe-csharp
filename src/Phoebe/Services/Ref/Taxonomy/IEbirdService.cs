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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEbirdServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEbirdService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the taxonomy used by eBird. #### Notes Each entry in the taxonomy contains a
    /// species code for example, barswa for Barn Swallow. You can download the taxonomy
    /// for selected species using the *species* query parameter with a comma separating
    /// each code. Otherwise the full taxonomy is downloaded.
    /// </summary>
    Task<List<EbirdRetrieveResponse>> Retrieve(
        EbirdRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEbirdService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEbirdServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEbirdServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ref/taxonomy/ebird</c>, but is otherwise the
    /// same as <see cref="IEbirdService.Retrieve(EbirdRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<EbirdRetrieveResponse>>> Retrieve(
        EbirdRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
