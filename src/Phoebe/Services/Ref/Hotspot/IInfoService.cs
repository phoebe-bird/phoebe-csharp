using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot.Info;

namespace Phoebe.Services.Ref.Hotspot;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInfoService
{
    IInfoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get information on the location of a hotspot. #### Notes This API call only
    /// works for hotspots. If you pass the location code for a private location or
    /// an invalid location code then an HTTP 410 (Gone) error is returned.
    /// </summary>
    Task<InfoRetrieveResponse> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get information on the location of a hotspot. #### Notes This API call only
    /// works for hotspots. If you pass the location code for a private location or
    /// an invalid location code then an HTTP 410 (Gone) error is returned.
    /// </summary>
    Task<InfoRetrieveResponse> Retrieve(
        string locID,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
