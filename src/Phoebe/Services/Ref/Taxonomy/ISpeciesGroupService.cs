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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeciesGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="List(SpeciesGroupListParams, CancellationToken)"/>
    Task<List<SpeciesGroupListResponse>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpeciesGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeciesGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeciesGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /ref/sppgroup/{speciesGrouping}`, but is otherwise the
    /// same as <see cref="ISpeciesGroupService.List(SpeciesGroupListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<SpeciesGroupListResponse>>> List(
        SpeciesGroupListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SpeciesGroupListParams, CancellationToken)"/>
    Task<HttpResponse<List<SpeciesGroupListResponse>>> List(
        ApiEnum<string, SpeciesGrouping> speciesGrouping,
        SpeciesGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
