using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Hotspot.Info;

namespace Phoebe.Services.Ref.Hotspot;

/// <inheritdoc/>
public sealed class InfoService : IInfoService
{
    readonly Lazy<IInfoServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInfoServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPhoebeClient _client;

    /// <inheritdoc/>
    public IInfoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InfoService(this._client.WithOptions(modifier));
    }

    public InfoService(IPhoebeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InfoServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<InfoRetrieveResponse> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InfoRetrieveResponse> Retrieve(
        string locID,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LocID = locID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InfoServiceWithRawResponse : IInfoServiceWithRawResponse
{
    readonly IPhoebeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInfoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InfoServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InfoServiceWithRawResponse(IPhoebeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LocID == null)
        {
            throw new PhoebeInvalidDataException("'parameters.LocID' cannot be null");
        }

        HttpRequest<InfoRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var info = await response
                    .Deserialize<InfoRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    info.Validate();
                }
                return info;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        string locID,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LocID = locID }, cancellationToken);
    }
}
