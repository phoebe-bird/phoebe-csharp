using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Region;

namespace Phoebe.Services.Ref;

/// <inheritdoc/>
public sealed class RegionService : IRegionService
{
    readonly Lazy<IRegionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IRegionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RegionService(this._client.WithOptions(modifier));
    }

    public RegionService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RegionServiceWithRawResponse(client.WithRawResponse));
        _adjacent = new(() => new AdjacentService(client));
        _info = new(() => new InfoService(client));
        _list = new(() => new ListService(client));
    }

    readonly Lazy<IAdjacentService> _adjacent;
    public IAdjacentService Adjacent
    {
        get { return _adjacent.Value; }
    }

    readonly Lazy<IInfoService> _info;
    public IInfoService Info
    {
        get { return _info.Value; }
    }

    readonly Lazy<IListService> _list;
    public IListService List
    {
        get { return _list.Value; }
    }
}

/// <inheritdoc/>
public sealed class RegionServiceWithRawResponse : IRegionServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RegionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegionServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _adjacent = new(() => new AdjacentServiceWithRawResponse(client));
        _info = new(() => new InfoServiceWithRawResponse(client));
        _list = new(() => new ListServiceWithRawResponse(client));
    }

    readonly Lazy<IAdjacentServiceWithRawResponse> _adjacent;
    public IAdjacentServiceWithRawResponse Adjacent
    {
        get { return _adjacent.Value; }
    }

    readonly Lazy<IInfoServiceWithRawResponse> _info;
    public IInfoServiceWithRawResponse Info
    {
        get { return _info.Value; }
    }

    readonly Lazy<IListServiceWithRawResponse> _list;
    public IListServiceWithRawResponse List
    {
        get { return _list.Value; }
    }
}
