using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations;

namespace Phoebe.Services.Data;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IObservationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IObservationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObservationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRecentService Recent { get; }

    IGeoService Geo { get; }

    INearestService Nearest { get; }
}

/// <summary>
/// A view of <see cref="IObservationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IObservationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObservationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRecentServiceWithRawResponse Recent { get; }

    IGeoServiceWithRawResponse Geo { get; }

    INearestServiceWithRawResponse Nearest { get; }
}
