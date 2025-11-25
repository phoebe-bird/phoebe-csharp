using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Services.Ref.Taxonomy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeciesGroupService
{
    ISpeciesGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of species groups, e.g. terns, finches, etc. #### Notes Merlin
    /// puts like birds together, with Falcons next to Hawks, whereas eBird follows
    /// taxonomic order.
    /// </summary>
    Task<List<SpeciesGroupListResponse>> List(
        SpeciesGroupListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of species groups, e.g. terns, finches, etc. #### Notes Merlin
    /// puts like birds together, with Falcons next to Hawks, whereas eBird follows
    /// taxonomic order.
    /// </summary>
    Task<List<SpeciesGroupListResponse>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
