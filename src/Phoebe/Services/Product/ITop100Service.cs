using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Phoebe.Core;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Services.Product;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITop100Service
{
    ITop100Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the top 100 contributors on a given date for a country or region.
    ///
    /// <para>#### Notes</para>
    ///
    /// <para>The results are updated every 15 minutes.</para>
    ///
    /// <para>When ordering by the number of completed checklists, the number of species
    /// seen will always be zero. Similarly when ordering by the number of species
    /// seen the number of completed checklists will always be zero. <b>Selected
    /// Response Field Notes</b></para>
    ///
    /// <para>profileHandle - if a user has enabled their profile, this is the handle
    /// to reach it via ebird.org/ebird/profile/{profileHandle}</para>
    ///
    /// <para>numSpecies - always zero when checklistSort parameter is true. Invalid
    /// observations ARE included in this total numCompleteChecklists - always zero
    /// when checklistSort parameter is false</para>
    /// </summary>
    Task<List<Top100RetrieveResponse>> Retrieve(
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the top 100 contributors on a given date for a country or region.
    ///
    /// <para>#### Notes</para>
    ///
    /// <para>The results are updated every 15 minutes.</para>
    ///
    /// <para>When ordering by the number of completed checklists, the number of species
    /// seen will always be zero. Similarly when ordering by the number of species
    /// seen the number of completed checklists will always be zero. <b>Selected
    /// Response Field Notes</b></para>
    ///
    /// <para>profileHandle - if a user has enabled their profile, this is the handle
    /// to reach it via ebird.org/ebird/profile/{profileHandle}</para>
    ///
    /// <para>numSpecies - always zero when checklistSort parameter is true. Invalid
    /// observations ARE included in this total numCompleteChecklists - always zero
    /// when checklistSort parameter is false</para>
    /// </summary>
    Task<List<Top100RetrieveResponse>> Retrieve(
        long d,
        Top100RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
