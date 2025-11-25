using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Forms;

namespace Phoebe.Services.Ref.Taxonomy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFormService
{
    IFormService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// For a species, get the list of subspecies recognised in the taxonomy. The
    /// results include the species that was passed in.
    /// </summary>
    Task<List<string>> List(
        FormListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For a species, get the list of subspecies recognised in the taxonomy. The
    /// results include the species that was passed in.
    /// </summary>
    Task<List<string>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
