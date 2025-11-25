using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.List;

namespace Phoebe.Services.Ref.Region;

public sealed class ListService : IListService
{
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public ListService(IPhoebeClient client)
    {
        _client = client;
    }

    public async Task<List<ListListResponse>> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var lists = await response
            .Deserialize<List<ListListResponse>>(cancellationToken)
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

    public async Task<List<ListListResponse>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.List(
            parameters with
            {
                ParentRegionCode = parentRegionCode,
            },
            cancellationToken
        );
    }
}
