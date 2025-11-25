using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.List;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IListService
{
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of sub-regions for a given country or region. #### Notes Not
    /// all combinations of region type and region code are valid. You can fetch all
    /// the subnational1 or subnational2 regions for a country however you can only
    /// specify a region type of 'country' when using 'world' as a region code.
    /// </summary>
    Task<List<ListListResponse>> List(
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of sub-regions for a given country or region. #### Notes Not
    /// all combinations of region type and region code are valid. You can fetch all
    /// the subnational1 or subnational2 regions for a country however you can only
    /// specify a region type of 'country' when using 'world' as a region code.
    /// </summary>
    Task<List<ListListResponse>> List(
        string parentRegionCode,
        ListListParams parameters,
        CancellationToken cancellationToken = default
    );
}
