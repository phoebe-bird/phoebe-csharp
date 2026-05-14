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
    readonly Lazy<IFormServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFormServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IFormService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormService(this._client.WithOptions(modifier));
    }

    public FormService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FormServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<string>> List(
        FormListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<string>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FormServiceWithRawResponse : IFormServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFormServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FormServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FormServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<string>>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<string>>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<string>>> List(
        string speciesCode,
        FormListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SpeciesCode = speciesCode }, cancellationToken);
    }
}
