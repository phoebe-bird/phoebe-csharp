using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Hotspot;
using Phoebe.Services.Ref.Hotspot;

namespace Phoebe.Services.Ref;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHotspotService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHotspotService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGeoService Geo { get; }

    IInfoService Info { get; }

    /// <summary>
    /// Hotspots in a region
    /// </summary>
    Task<List<HotspotListResponse>> List(
        HotspotListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(HotspotListParams, CancellationToken)"/>
    Task<List<HotspotListResponse>> List(
        string regionCode,
        HotspotListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
