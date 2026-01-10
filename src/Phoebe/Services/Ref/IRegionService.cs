using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Region;

namespace Phoebe.Services.Ref;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRegionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAdjacentService Adjacent { get; }

    IInfoService Info { get; }

    IListService List { get; }
}

/// <summary>
/// A view of <see cref="IRegionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAdjacentServiceWithRawResponse Adjacent { get; }

    IInfoServiceWithRawResponse Info { get; }

    IListServiceWithRawResponse List { get; }
}
