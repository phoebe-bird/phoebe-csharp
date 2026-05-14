using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.List;

namespace Phoebe.Services.Ref.Region;

/// <inheritdoc/>
public sealed class ListService : IListService
{
    readonly Lazy<IListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    public ListService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ListServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ListListResponse>> List(
        ListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<ListListResponse>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(
            parameters with
            {
                ParentRegionCode = parentRegionCode,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ListServiceWithRawResponse : IListServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ListServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ListListResponse>>> List(
        ListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ParentRegionCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.ParentRegionCode' cannot be null");
        }

        HttpRequest<ListListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lists = await response
                    .Deserialize<List<ListListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in lists)
                    {
                        item.Validate();
                    }
                }
                return lists;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<ListListResponse>>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(
            parameters with
            {
                ParentRegionCode = parentRegionCode,
            },
            cancellationToken
        );
    }
}
