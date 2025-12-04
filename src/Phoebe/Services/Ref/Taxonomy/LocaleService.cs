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
    /// <inheritdoc/>
    public ILocaleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LocaleService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public LocaleService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<LocaleListResponse>> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var locales = await response
            .Deserialize<List<LocaleListResponse>>(cancellationToken)
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
}
