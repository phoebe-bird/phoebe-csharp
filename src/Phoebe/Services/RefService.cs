using System;
using Phoebe.Core;
using Phoebe.Services.Ref;

namespace Phoebe.Services;

/// <inheritdoc/>
public sealed class RefService : IRefService
{
    readonly Lazy<IRefServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRefServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IRefService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefService(this._client.WithOptions(modifier));
    }

    public RefService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RefServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class RefServiceWithRawResponse : IRefServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRefServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RefServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RefServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _region = new(() => new RegionServiceWithRawResponse(client));
        _hotspot = new(() => new HotspotServiceWithRawResponse(client));
        _taxonomy = new(() => new TaxonomyServiceWithRawResponse(client));
    }

    readonly Lazy<IRegionServiceWithRawResponse> _region;
    public IRegionServiceWithRawResponse Region
    {
        get { return _region.Value; }
    }

    readonly Lazy<IHotspotServiceWithRawResponse> _hotspot;
    public IHotspotServiceWithRawResponse Hotspot
    {
        get { return _hotspot.Value; }
    }

    readonly Lazy<ITaxonomyServiceWithRawResponse> _taxonomy;
    public ITaxonomyServiceWithRawResponse Taxonomy
    {
        get { return _taxonomy.Value; }
    }
}
