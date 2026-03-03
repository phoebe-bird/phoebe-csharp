using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Lists;
using Phoebe.Services.Product.Lists;

namespace Phoebe.Services.Product;

/// <summary>
/// The data/obs end-points are used to fetch observations submitted to eBird in
/// checklists. There are two categories of end-point: 1. Fetch observations for a
/// specific country, region or location. 2. Fetch observations for nearby locations
/// - up to a distance of 50km. Each end-point supports optional query parameters
/// which allow you to filter the list of observations returned.
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

    IHistoricalService Historical { get; }

    /// <summary>
    /// Get information on the most recently submitted checklists for a region.
    /// </summary>
    Task<List<ListRetrieveResponse>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<List<ListRetrieveResponse>> Retrieve(
        string regionCode,
        ListRetrieveParams? parameters = null,
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

    IHistoricalServiceWithRawResponse Historical { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /product/lists/{regionCode}`, but is otherwise the
    /// same as <see cref="IListService.Retrieve(ListRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ListRetrieveResponse>>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<ListRetrieveResponse>>> Retrieve(
        string regionCode,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
