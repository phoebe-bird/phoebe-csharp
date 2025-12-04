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
    /// <inheritdoc/>
    public IChecklistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChecklistService(this._client.WithOptions(modifier));
    }

    readonly IPhoebeClient _client;

    public ChecklistService(IPhoebeClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChecklistViewResponse> View(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ChecklistViewResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ChecklistViewResponse> View(
        string subID,
        ChecklistViewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.View(parameters with { SubID = subID }, cancellationToken);
    }
}
