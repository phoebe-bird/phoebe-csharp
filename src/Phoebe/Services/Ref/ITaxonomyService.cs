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
    ITaxonomyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEbirdService Ebird { get; }

    IFormService Forms { get; }

    ILocaleService Locales { get; }

    IVersionService Versions { get; }

    ISpeciesGroupService SpeciesGroups { get; }
}
