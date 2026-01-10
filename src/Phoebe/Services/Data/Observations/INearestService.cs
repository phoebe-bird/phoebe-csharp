using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations.Nearest;

namespace Phoebe.Services.Data.Observations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INearestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INearestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INearestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGeoSpecieService GeoSpecies { get; }
}

/// <summary>
/// A view of <see cref="INearestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INearestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INearestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGeoSpecieServiceWithRawResponse GeoSpecies { get; }
}
