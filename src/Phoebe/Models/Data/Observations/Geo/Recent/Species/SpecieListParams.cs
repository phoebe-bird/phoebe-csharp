using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Phoebe.Core;

namespace Phoebe.Models.Data.Observations.Geo.Recent.Species;

/// <summary>
/// Get all observations of a species, seen up to 30 days ago, at any location within
/// a radius of up to 50 kilometers, from a given set of coordinates. Results include
/// only the most recent observation from each location in the region specified.
///
/// <para>#### URL parameters</para>
///
/// <para>| Name | Description | | ---------- | ----------- | | speciesCode | The
/// eBird species code. | #### Notes The species code is typically a 6-letter code,
/// e.g. horlar for Horned Lark. You can get complete set of species code from the
/// GET eBird Taxonomy end-point.</para>
/// </summary>
public sealed record class SpecieListParams : ParamsBase
{
    public string? SpeciesCode { get; init; }

    public required float Lat
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<float>("lat");
        }
        init { this._rawQueryData.Set("lat", value); }
    }

    public required float Lng
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<float>("lng");
        }
        init { this._rawQueryData.Set("lng", value); }
    }

    /// <summary>
    /// The number of days back to fetch observations.
    /// </summary>
    public long? Back
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("back");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("back", value);
        }
    }

    /// <summary>
    /// The search radius from the given position, in kilometers.
    /// </summary>
    public long? Dist
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("dist");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("dist", value);
        }
    }

    /// <summary>
    /// Only fetch observations from hotspots
    /// </summary>
    public bool? Hotspot
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hotspot");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hotspot", value);
        }
    }

    /// <summary>
    /// Include observations which have not yet been reviewed.
    /// </summary>
    public bool? IncludeProvisional
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeProvisional");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeProvisional", value);
        }
    }

    /// <summary>
    /// Only fetch this number of observations
    /// </summary>
    public long? MaxResults
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxResults", value);
        }
    }

    /// <summary>
    /// Use this language for species common names
    /// </summary>
    public string? SppLocale
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sppLocale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sppLocale", value);
        }
    }

    public SpecieListParams() { }

    public SpecieListParams(SpecieListParams specieListParams)
        : base(specieListParams)
    {
        this.SpeciesCode = specieListParams.SpeciesCode;
    }

    public SpecieListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpecieListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SpecieListParams FromRawUnchecked(
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
                + string.Format("/data/obs/geo/recent/{0}", this.SpeciesCode)
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
