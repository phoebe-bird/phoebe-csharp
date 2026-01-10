using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Taxonomy;

namespace Phoebe.Services.Ref;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITaxonomyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITaxonomyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITaxonomyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEbirdService Ebird { get; }

    IFormService Forms { get; }

    ILocaleService Locales { get; }

    IVersionService Versions { get; }

    ISpeciesGroupService SpeciesGroups { get; }
}

/// <summary>
/// A view of <see cref="ITaxonomyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITaxonomyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITaxonomyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEbirdServiceWithRawResponse Ebird { get; }

    IFormServiceWithRawResponse Forms { get; }

    ILocaleServiceWithRawResponse Locales { get; }

    IVersionServiceWithRawResponse Versions { get; }

    ISpeciesGroupServiceWithRawResponse SpeciesGroups { get; }
}
