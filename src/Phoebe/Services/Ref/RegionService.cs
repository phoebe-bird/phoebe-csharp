using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Region;

namespace Phoebe.Services.Ref;

public sealed class RegionService : IRegionService
{
    public IRegionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RegionService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public RegionService(IPhoebeClient client)
    {
        _client = client;
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
