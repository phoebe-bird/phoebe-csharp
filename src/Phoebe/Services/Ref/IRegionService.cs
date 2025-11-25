using System;
using Phoebe.Core;
using Phoebe.Services.Ref.Region;

namespace Phoebe.Services.Ref;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRegionService
{
    IRegionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAdjacentService Adjacent { get; }

    IInfoService Info { get; }

    IListService List { get; }
}
