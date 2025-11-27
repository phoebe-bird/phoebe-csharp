using System;
using Phoebe.Core;
using Phoebe.Services.Product;

namespace Phoebe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IListService Lists { get; }

    ITop100Service Top100 { get; }

    IStatService Stats { get; }

    ISpeciesListService SpeciesList { get; }

    IChecklistService Checklist { get; }
}
