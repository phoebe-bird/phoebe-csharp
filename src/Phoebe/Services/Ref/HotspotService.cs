using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Hotspot;
using Phoebe.Services.Ref.Hotspot;

namespace Phoebe.Services.Ref;

/// <inheritdoc/>
public sealed class HotspotService : IHotspotService
{
    readonly Lazy<IHotspotServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHotspotServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IHotspotService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HotspotService(this._client.WithOptions(modifier));
    }

    public HotspotService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HotspotServiceWithRawResponse(client.WithRawResponse));
        _geo = new(() => new GeoService(client));
        _info = new(() => new InfoService(client));
    }

    readonly Lazy<IGeoService> _geo;
    public IGeoService Geo
    {
        get { return _geo.Value; }
    }

    readonly Lazy<IInfoService> _info;
    public IInfoService Info
    {
        get { return _info.Value; }
    }

    /// <inheritdoc/>
    public async Task<List<HotspotListResponse>> List(
        HotspotListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<HotspotListResponse>> List(
        string regionCode,
        HotspotListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class HotspotServiceWithRawResponse : IHotspotServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHotspotServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HotspotServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HotspotServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;

        _geo = new(() => new GeoServiceWithRawResponse(client));
        _info = new(() => new InfoServiceWithRawResponse(client));
    }

    readonly Lazy<IGeoServiceWithRawResponse> _geo;
    public IGeoServiceWithRawResponse Geo
    {
        get { return _geo.Value; }
    }

    readonly Lazy<IInfoServiceWithRawResponse> _info;
    public IInfoServiceWithRawResponse Info
    {
        get { return _info.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<HotspotListResponse>>> List(
        HotspotListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.RegionCode' cannot be null");
        }

        HttpRequest<HotspotListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var hotspots = await response
                    .Deserialize<List<HotspotListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in hotspots)
                    {
                        item.Validate();
                    }
                }
                return hotspots;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<HotspotListResponse>>> List(
        string regionCode,
        HotspotListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RegionCode = regionCode }, cancellationToken);
    }
}
