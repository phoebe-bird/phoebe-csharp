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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeciesListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="List(SpeciesListListParams, CancellationToken)"/>
    Task<List<string>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpeciesListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeciesListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeciesListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /product/spplist/{regionCode}`, but is otherwise the
    /// same as <see cref="ISpeciesListService.List(SpeciesListListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<string>>> List(
        SpeciesListListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SpeciesListListParams, CancellationToken)"/>
    Task<HttpResponse<List<string>>> List(
        string regionCode,
        SpeciesListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
