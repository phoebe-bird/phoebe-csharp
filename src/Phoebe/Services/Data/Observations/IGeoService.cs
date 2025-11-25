using System;
using Phoebe.Core;
using Geo = Phoebe.Services.Data.Observations.Geo;

namespace Phoebe.Services.Data.Observations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGeoService
{
    IGeoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Geo::IRecentService Recent { get; }
}
