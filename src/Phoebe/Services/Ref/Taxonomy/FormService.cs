using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.Forms;

namespace Phoebe.Services.Ref.Taxonomy;

/// <inheritdoc/>
public sealed class FormService : IFormService
{
    /// <inheritdoc/>
    public IFormService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public FormService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<string>> List(
        FormListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpeciesCode == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SpeciesCode' cannot be null");
        }

        HttpRequest<FormListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<List<string>>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<string>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}
