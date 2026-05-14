using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Versions;

namespace Phoebe.Services.Ref.Taxonomy;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<VersionListResponse>> List(
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<VersionListResponse>>> List(
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VersionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var versions = await response
                    .Deserialize<List<VersionListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in versions)
                    {
                        item.Validate();
                    }
                }
                return versions;
            }
        );
    }
}
