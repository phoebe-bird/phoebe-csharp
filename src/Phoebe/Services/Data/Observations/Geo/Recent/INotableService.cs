using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Data.Observations;
using Phoebe.Models.Data.Observations.Geo.Recent.Notable;

namespace Phoebe.Services.Data.Observations.Geo.Recent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INotableService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotableServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotableService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of notable observations (up to 30 days ago) of birds seen at
    /// locations within a radius of up to 50 kilometers, from a given set of coordinates.
    /// Notable observations can be for locally or nationally rare species or are
    /// otherwise unusual, for example over-wintering birds in a species which is
    /// normally only a summer visitor.
    /// </summary>
    Task<List<Observation>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INotableService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotableServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotableServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /data/obs/geo/recent/notable`, but is otherwise the
    /// same as <see cref="INotableService.List(NotableListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Observation>>> List(
        NotableListParams parameters,
        CancellationToken cancellationToken = default
    );
}
