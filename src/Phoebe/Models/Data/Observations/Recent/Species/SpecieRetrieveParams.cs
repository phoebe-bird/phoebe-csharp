using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Phoebe.Core;

namespace Phoebe.Models.Data.Observations.Recent.Species;

/// <summary>
/// Get the recent observations, up to 30 days ago, of a particular species in a country,
/// region or location. Results include only the most recent observation from each
/// location in the region specified. #### Notes
///
/// <para>The species code is typically a 6-letter code, e.g. cangoo for Canada Goose.
/// You can get complete set of species code from the GET eBird Taxonomy end-point.</para>
///
/// <para>When using the *r* query parameter set the *regionCode* URL parameter to
/// an empty string.</para>
/// </summary>
public sealed record class SpecieRetrieveParams : ParamsBase
{
    public required string RegionCode { get; init; }

    public string? SpeciesCode { get; init; }

    /// <summary>
    /// The number of days back to fetch observations.
    /// </summary>
    public long? Back
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "back"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "back", value);
        }
    }

    /// <summary>
    /// Only fetch observations from hotspots
    /// </summary>
    public bool? Hotspot
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "hotspot"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "hotspot", value);
        }
    }

    /// <summary>
    /// Include observations which have not yet been reviewed.
    /// </summary>
    public bool? IncludeProvisional
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "includeProvisional"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "includeProvisional", value);
        }
    }

    /// <summary>
    /// Only fetch this number of observations
    /// </summary>
    public long? MaxResults
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "maxResults"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "maxResults", value);
        }
    }

    /// <summary>
    /// Fetch observations from up to 10 locations
    /// </summary>
    public IReadOnlyList<string>? R
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawQueryData, "r"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "r", value);
        }
    }

    /// <summary>
    /// Use this language for species common names
    /// </summary>
    public string? SppLocale
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "sppLocale"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "sppLocale", value);
        }
    }

    public SpecieRetrieveParams() { }

    public SpecieRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpecieRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SpecieRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/data/obs/{0}/recent/{1}", this.RegionCode, this.SpeciesCode)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
