using System;
using Phoebe.Core;
using Phoebe.Services.Product;

namespace Phoebe.Services;

public sealed class ProductService : IProductService
{
    public IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public ProductService(IPhoebeClient client)
    {
        _client = client;
        _lists = new(() => new ListService(client));
        _top100 = new(() => new Top100Service(client));
        _stats = new(() => new StatService(client));
        _speciesList = new(() => new SpeciesListService(client));
        _checklist = new(() => new ChecklistService(client));
    }

    readonly Lazy<IListService> _lists;
    public IListService Lists
    {
        get { return _lists.Value; }
    }

    readonly Lazy<ITop100Service> _top100;
    public ITop100Service Top100
    {
        get { return _top100.Value; }
    }

    readonly Lazy<IStatService> _stats;
    public IStatService Stats
    {
        get { return _stats.Value; }
    }

    readonly Lazy<ISpeciesListService> _speciesList;
    public ISpeciesListService SpeciesList
    {
        get { return _speciesList.Value; }
    }

    readonly Lazy<IChecklistService> _checklist;
    public IChecklistService Checklist
    {
        get { return _checklist.Value; }
    }
}
