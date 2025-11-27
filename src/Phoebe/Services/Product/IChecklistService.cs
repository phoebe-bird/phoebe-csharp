using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Checklist;

namespace Phoebe.Services.Product;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChecklistService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChecklistService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the details and observations of a checklist. #### Notes Do NOT use this
    /// to download large amounts of data. You will be banned if you do. In the fields
    /// for each observation, the following fields are duplicates or obsolete and
    /// will be removed at a future date: *howManyAtleast*, *howManyAtmost*, *hideFlags*,
    /// *projId*, *subId*, *subnational1Code* and *present*.
    /// </summary>
    Task<ChecklistViewResponse> View(
        ChecklistViewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="View(ChecklistViewParams, CancellationToken)"/>
    Task<ChecklistViewResponse> View(
        string subID,
        ChecklistViewParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
