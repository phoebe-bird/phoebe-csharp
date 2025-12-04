using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Taxonomy;

namespace Phoebe.Services.Ref;

/// <inheritdoc/>
public sealed class TaxonomyService : ITaxonomyService
{
    /// <inheritdoc/>
    public ITaxonomyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TaxonomyService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public TaxonomyService(IPhoebeClient client)
    {
        _client = client;
        _ebird = new(() => new EbirdService(client));
        _forms = new(() => new FormService(client));
        _locales = new(() => new LocaleService(client));
        _versions = new(() => new VersionService(client));
        _speciesGroups = new(() => new SpeciesGroupService(client));
    }

    readonly Lazy<IEbirdService> _ebird;
    public IEbirdService Ebird
    {
        get { return _ebird.Value; }
    }

    readonly Lazy<IFormService> _forms;
    public IFormService Forms
    {
        get { return _forms.Value; }
    }

    readonly Lazy<ILocaleService> _locales;
    public ILocaleService Locales
    {
        get { return _locales.Value; }
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    readonly Lazy<ISpeciesGroupService> _speciesGroups;
    public ISpeciesGroupService SpeciesGroups
    {
        get { return _speciesGroups.Value; }
    }
}
