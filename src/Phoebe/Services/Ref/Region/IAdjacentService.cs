using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// With the ref/geo end-point you can find a country's or region's neighbours.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAdjacentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAdjacentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdjacentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of countries or regions that share a border with this one. ####
    /// Notes Only subnational2 codes in the United States, New Zealand, or Mexico
    /// are currently supported
    /// </summary>
    Task<List<AdjacentListResponse>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AdjacentListParams, CancellationToken)"/>
    Task<List<AdjacentListResponse>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAdjacentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAdjacentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdjacentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /ref/adjacent/{regionCode}`, but is otherwise the
    /// same as <see cref="IAdjacentService.List(AdjacentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AdjacentListResponse>>> List(
        AdjacentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AdjacentListParams, CancellationToken)"/>
    Task<HttpResponse<List<AdjacentListResponse>>> List(
        string regionCode,
        AdjacentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
