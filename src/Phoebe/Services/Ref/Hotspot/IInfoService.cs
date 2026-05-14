using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot.Info;

namespace Phoebe.Services.Ref.Hotspot;

/// <summary>
/// With the ref/hotspot end-points you can find the hotspots for a given country
/// or region or nearby hotspots
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInfoService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInfoServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInfoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get information on the location of a hotspot. #### Notes This API call only
    /// works for hotspots. If you pass the location code for a private location or an
    /// invalid location code then an HTTP 410 (Gone) error is returned.
    /// </summary>
    Task<InfoRetrieveResponse> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InfoRetrieveParams, CancellationToken)"/>
    Task<InfoRetrieveResponse> Retrieve(
        string locID,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInfoService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInfoServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInfoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ref/hotspot/info/{locId}</c>, but is otherwise the
    /// same as <see cref="IInfoService.Retrieve(InfoRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InfoRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        string locID,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
