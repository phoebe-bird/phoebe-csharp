using System;
using Phoebe.Core;
using Phoebe.Services.Data.Observations.Nearest;

namespace Phoebe.Services.Data.Observations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INearestService
{
    INearestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGeoSpecieService GeoSpecies { get; }
}
