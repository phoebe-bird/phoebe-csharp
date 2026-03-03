using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.List;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// The ref/region end-points return information on regions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IListService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of sub-regions for a given country or region. #### Notes Not
    /// all combinations of region type and region code are valid. You can fetch all
    /// the subnational1 or subnational2 regions for a country however you can only
    /// specify a region type of 'country' when using 'world' as a region code.
    /// </summary>
    Task<List<ListListResponse>> List(
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ListListParams, CancellationToken)"/>
    Task<List<ListListResponse>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /ref/region/list/{regionType}/{parentRegionCode}`, but is otherwise the
    /// same as <see cref="IListService.List(ListListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ListListResponse>>> List(
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ListListParams, CancellationToken)"/>
    Task<HttpResponse<List<ListListResponse>>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );
}
