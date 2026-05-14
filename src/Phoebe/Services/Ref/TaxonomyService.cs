using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Taxonomy;

namespace Phoebe.Services.Ref;

/// <inheritdoc/>
public sealed class TaxonomyService : ITaxonomyService
{
    readonly Lazy<ITaxonomyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITaxonomyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ITaxonomyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TaxonomyService(this._client.WithOptions(modifier));
    }

    public TaxonomyService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TaxonomyServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class TaxonomyServiceWithRawResponse : ITaxonomyServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITaxonomyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TaxonomyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TaxonomyServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _ebird = new(() => new EbirdServiceWithRawResponse(client));
        _forms = new(() => new FormServiceWithRawResponse(client));
        _locales = new(() => new LocaleServiceWithRawResponse(client));
        _versions = new(() => new VersionServiceWithRawResponse(client));
        _speciesGroups = new(() => new SpeciesGroupServiceWithRawResponse(client));
    }

    readonly Lazy<IEbirdServiceWithRawResponse> _ebird;
    public IEbirdServiceWithRawResponse Ebird
    {
        get { return _ebird.Value; }
    }

    readonly Lazy<IFormServiceWithRawResponse> _forms;
    public IFormServiceWithRawResponse Forms
    {
        get { return _forms.Value; }
    }

    readonly Lazy<ILocaleServiceWithRawResponse> _locales;
    public ILocaleServiceWithRawResponse Locales
    {
        get { return _locales.Value; }
    }

    readonly Lazy<IVersionServiceWithRawResponse> _versions;
    public IVersionServiceWithRawResponse Versions
    {
        get { return _versions.Value; }
    }

    readonly Lazy<ISpeciesGroupServiceWithRawResponse> _speciesGroups;
    public ISpeciesGroupServiceWithRawResponse SpeciesGroups
    {
        get { return _speciesGroups.Value; }
    }
}
