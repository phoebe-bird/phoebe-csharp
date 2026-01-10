using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Checklist;

namespace Phoebe.Services.Product;

/// <inheritdoc/>
public sealed class ChecklistService : IChecklistService
{
    readonly Lazy<IChecklistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChecklistServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IChecklistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChecklistService(this._client.WithOptions(modifier));
    }

    public ChecklistService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChecklistServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChecklistViewResponse> View(
        ChecklistViewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.View(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChecklistViewResponse> View(
        string subID,
        ChecklistViewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.View(parameters with { SubID = subID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ChecklistServiceWithRawResponse : IChecklistServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChecklistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChecklistServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChecklistServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChecklistViewResponse>> View(
        ChecklistViewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubID == null)
        {
            throw new PhoebeInvalidDataException("'parameters.SubID' cannot be null");
        }

        HttpRequest<ChecklistViewParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ChecklistViewResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChecklistViewResponse>> View(
        string subID,
        ChecklistViewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.View(parameters with { SubID = subID }, cancellationToken);
    }
}
