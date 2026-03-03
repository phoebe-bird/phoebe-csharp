using System;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Services.Ref.Region;

/// <summary>
/// The ref/region end-points return information on regions.
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

    /// <inheritdoc cref="Retrieve(InfoRetrieveParams, CancellationToken)"/>
    Task<InfoRetrieveResponse> Retrieve(
        string regionCode,
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
    /// Returns a raw HTTP response for `get /ref/region/info/{regionCode}`, but is otherwise the
    /// same as <see cref="IInfoService.Retrieve(InfoRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        InfoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InfoRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InfoRetrieveResponse>> Retrieve(
        string regionCode,
        InfoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
