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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFormServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFormService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// For a species, get the list of subspecies recognised in the taxonomy. The
    /// results include the species that was passed in.
    /// </summary>
    Task<List<string>> List(
        FormListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FormListParams, CancellationToken)"/>
    Task<List<string>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFormService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFormServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFormServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ref/taxon/forms/{speciesCode}</c>, but is otherwise the
    /// same as <see cref="IFormService.List(FormListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<string>>> List(
        FormListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FormListParams, CancellationToken)"/>
    Task<HttpResponse<List<string>>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
