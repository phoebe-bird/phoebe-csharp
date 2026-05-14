using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot.Geo;

namespace Phoebe.Services.Ref.Hotspot;

/// <summary>
/// With the ref/hotspot end-points you can find the hotspots for a given country
/// or region or nearby hotspots
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    /// <summary>
    /// Get the list of hotspots, within a radius of up to 50 kilometers, from a given
    /// set of coordinates.
    /// </summary>
    Task<List<GeoRetrieveResponse>> Retrieve(
        GeoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ref/hotspot/geo</c>, but is otherwise the
    /// same as <see cref="IGeoService.Retrieve(GeoRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<GeoRetrieveResponse>>> Retrieve(
        GeoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
