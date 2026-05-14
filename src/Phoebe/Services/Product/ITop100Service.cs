using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Services.Product;

/// <summary>
/// The product end-points make it easy to get the information shown in various pages
/// on the eBird web site: 1. The Top 100 contributors on a given date. 2. The checklists
/// submitted on a given date. 3. The most recent checklists submitted. 4. A summary
/// of the checklists submitted on a given date. 5. The details and all the observations
/// of a checklist.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITop100Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITop100ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITop100Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the top 100 contributors on a given date for a country or region.
    ///
    /// <para>#### Notes</para>
    ///
    /// <para>The results are updated every 15 minutes.</para>
    ///
    /// <para>When ordering by the number of completed checklists, the number of species
    /// seen will always be zero. Similarly when ordering by the number of species seen
    /// the number of completed checklists will always be zero. <b>Selected Response
    /// Field Notes</b></para>
    ///
    /// <para>profileHandle - if a user has enabled their profile, this is the handle to
    /// reach it via ebird.org/ebird/profile/{profileHandle}</para>
    ///
    /// <para>numSpecies - always zero when checklistSort parameter is true. Invalid
    /// observations ARE included in this total numCompleteChecklists - always zero when
    /// checklistSort parameter is false</para>
    /// </summary>
    Task<List<Top100RetrieveResponse>> Retrieve(
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Top100RetrieveParams, CancellationToken)"/>
    Task<List<Top100RetrieveResponse>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITop100Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITop100ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITop100ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /product/top100/{regionCode}/{y}/{m}/{d}</c>, but is otherwise the
    /// same as <see cref="ITop100Service.Retrieve(Top100RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Top100RetrieveResponse>>> Retrieve(
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Top100RetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<Top100RetrieveResponse>>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
