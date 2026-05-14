using System;
using Phoebe.Core;
using Geo = Phoebe.Services.Data.Observations.Geo;

namespace Phoebe.Services.Data.Observations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGeoService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGeoServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Geo::IRecentService Recent { get; }
}

/// <summary>
/// A view of <see cref="IGeoService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGeoServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Geo::IRecentServiceWithRawResponse Recent { get; }
}
