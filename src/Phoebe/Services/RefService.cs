using System;
using Phoebe.Core;
using Phoebe.Services.Ref;

namespace Phoebe.Services;

/// <inheritdoc />
public sealed class RefService : IRefService
{
    /// <inheritdoc/>
    public IRefService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public RefService(IPhoebeClient client)
    {
        _client = client;
        _region = new(() => new RegionService(client));
        _hotspot = new(() => new HotspotService(client));
        _taxonomy = new(() => new TaxonomyService(client));
    }

    readonly Lazy<IRegionService> _region;
    public IRegionService Region
    {
        get { return _region.Value; }
    }

    readonly Lazy<IHotspotService> _hotspot;
    public IHotspotService Hotspot
    {
        get { return _hotspot.Value; }
    }

    readonly Lazy<ITaxonomyService> _taxonomy;
    public ITaxonomyService Taxonomy
    {
        get { return _taxonomy.Value; }
    }
}
