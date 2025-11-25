using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.SpeciesList;

namespace Phoebe.Services.Product;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeciesListService
{
    ISpeciesListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a list of species codes ever seen in a region, in taxonomic order (species
    /// taxa only) #### Notes The results are usually updated every 10 seconds for
    /// locations, every day for larger regions.
    /// </summary>
    Task<List<string>> List(
        SpeciesListListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of species codes ever seen in a region, in taxonomic order (species
    /// taxa only) #### Notes The results are usually updated every 10 seconds for
    /// locations, every day for larger regions.
    /// </summary>
    Task<List<string>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
