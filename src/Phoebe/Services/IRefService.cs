using System;
using Phoebe.Core;
using Phoebe.Services.Ref;

namespace Phoebe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRefService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRefServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRefService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRegionService Region { get; }

    IHotspotService Hotspot { get; }

    ITaxonomyService Taxonomy { get; }
}

/// <summary>
/// A view of <see cref="IRefService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRefServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRefServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRegionServiceWithRawResponse Region { get; }

    IHotspotServiceWithRawResponse Hotspot { get; }

    ITaxonomyServiceWithRawResponse Taxonomy { get; }
}
