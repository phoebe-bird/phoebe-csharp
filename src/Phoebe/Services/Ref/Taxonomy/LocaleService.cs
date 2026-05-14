using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Locales;

namespace Phoebe.Services.Ref.Taxonomy;

/// <inheritdoc/>
public sealed class LocaleService : ILocaleService
{
    readonly Lazy<ILocaleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILocaleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public ILocaleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LocaleService(this._client.WithOptions(modifier));
    }

    public LocaleService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LocaleServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<LocaleListResponse>> List(
        LocaleListParams? parameters = null,
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
public sealed class LocaleServiceWithRawResponse : ILocaleServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILocaleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LocaleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LocaleServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<LocaleListResponse>>> List(
        LocaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LocaleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var locales = await response
                    .Deserialize<List<LocaleListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in locales)
                    {
                        item.Validate();
                    }
                }
                return locales;
            }
        );
    }
}
