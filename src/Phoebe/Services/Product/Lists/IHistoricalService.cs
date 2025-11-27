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
