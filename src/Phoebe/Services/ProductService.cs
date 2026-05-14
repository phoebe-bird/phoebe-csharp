using System;
using Phoebe.Core;
using Phoebe.Services.Product;

namespace Phoebe.Services;

/// <inheritdoc/>
public sealed class ProductService : IProductService
{
    readonly Lazy<IProductServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductService(this._client.WithOptions(modifier));
    }

    public ProductService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProductServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class ProductServiceWithRawResponse : IProductServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProductServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _lists = new(() => new ListServiceWithRawResponse(client));
        _top100 = new(() => new Top100ServiceWithRawResponse(client));
        _stats = new(() => new StatServiceWithRawResponse(client));
        _speciesList = new(() => new SpeciesListServiceWithRawResponse(client));
        _checklist = new(() => new ChecklistServiceWithRawResponse(client));
    }

    readonly Lazy<IListServiceWithRawResponse> _lists;
    public IListServiceWithRawResponse Lists
    {
        get { return _lists.Value; }
    }

    readonly Lazy<ITop100ServiceWithRawResponse> _top100;
    public ITop100ServiceWithRawResponse Top100
    {
        get { return _top100.Value; }
    }

    readonly Lazy<IStatServiceWithRawResponse> _stats;
    public IStatServiceWithRawResponse Stats
    {
        get { return _stats.Value; }
    }

    readonly Lazy<ISpeciesListServiceWithRawResponse> _speciesList;
    public ISpeciesListServiceWithRawResponse SpeciesList
    {
        get { return _speciesList.Value; }
    }

    readonly Lazy<IChecklistServiceWithRawResponse> _checklist;
    public IChecklistServiceWithRawResponse Checklist
    {
        get { return _checklist.Value; }
    }
}
