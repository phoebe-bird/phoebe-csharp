using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Stats;

namespace Phoebe.Services.Product;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IStatService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStatService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a summary of the number of checklist submitted, species seen and contributors
    /// on a given date for a country or region. #### Notes The results are updated
    /// every 15 minutes.
    /// </summary>
    Task<StatRetrieveResponse> Retrieve(
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(StatRetrieveParams, CancellationToken)"/>
    Task<StatRetrieveResponse> Retrieve(
        long d,
        StatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
