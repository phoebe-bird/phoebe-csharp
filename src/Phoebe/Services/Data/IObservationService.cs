using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations;

namespace Phoebe.Services.Data;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IObservationService
{
    IObservationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRecentService Recent { get; }

    IGeoService Geo { get; }

    INearestService Nearest { get; }
}
