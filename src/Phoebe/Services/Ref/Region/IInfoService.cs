using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInfoService
{
    IInfoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get information on the name and geographical area covered by a region. #### Notes
    ///
    /// <para>Taking Madison County, New York, USA (location code US-NY-053) as an
    /// example the various values for the regionNameFormat query parameter work as follows:</para>
    ///
    /// <para>| Value | Description | Result | | ------| ----------- | ------ | |
    /// detailed | return a detailed description | Madison County, New York, US |
    /// | detailednoqual | return the name to the subnational1 level | Madison, New
    /// York | | full | return the full description | Madison, New York, United States
    /// | | namequal | return the qualified name | Madison County | | nameonly |
    /// return only the name of the region | Madison | | revdetailed | return the
    /// detailed description in reverse | US, New York, Madison County |</para>
    /// </summary>
    Task<InfoRetrieveResponse> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get information on the name and geographical area covered by a region. #### Notes
    ///
    /// <para>Taking Madison County, New York, USA (location code US-NY-053) as an
    /// example the various values for the regionNameFormat query parameter work as follows:</para>
    ///
    /// <para>| Value | Description | Result | | ------| ----------- | ------ | |
    /// detailed | return a detailed description | Madison County, New York, US |
    /// | detailednoqual | return the name to the subnational1 level | Madison, New
    /// York | | full | return the full description | Madison, New York, United States
    /// | | namequal | return the qualified name | Madison County | | nameonly |
    /// return only the name of the region | Madison | | revdetailed | return the
    /// detailed description in reverse | US, New York, Madison County |</para>
    /// </summary>
    Task<InfoRetrieveResponse> Retrieve(
        string regionCode,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
