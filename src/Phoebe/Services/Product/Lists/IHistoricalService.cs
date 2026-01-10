using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Services.Product.Lists;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHistoricalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHistoricalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoricalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get information on the checklists submitted on a given date for a country
    /// or region.
    /// </summary>
    Task<List<HistoricalRetrieveResponse>> Retrieve(
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HistoricalRetrieveParams, CancellationToken)"/>
    Task<List<HistoricalRetrieveResponse>> Retrieve(
        long d,
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHistoricalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHistoricalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoricalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /product/lists/{regionCode}/{y}/{m}/{d}`, but is otherwise the
    /// same as <see cref="IHistoricalService.Retrieve(HistoricalRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<HistoricalRetrieveResponse>>> Retrieve(
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HistoricalRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<HistoricalRetrieveResponse>>> Retrieve(
        long d,
        HistoricalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
