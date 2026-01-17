using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Phoebe.Core;

namespace Phoebe.Models.Data.Observations.Nearest.GeoSpecies;

/// <summary>
/// Find the nearest locations where a species has been seen recently. #### Notes
/// The species code is typically a 6-letter code, e.g. barswa for Barn Swallow.
/// You can get complete set of species code from the GET eBird Taxonomy end-point.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GeoSpecieListParams : ParamsBase
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
    /// Only fetch observations within this distance of the provided lat/lng
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
    /// Only fetch up to this number of observations
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

    public GeoSpecieListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeoSpecieListParams(GeoSpecieListParams geoSpecieListParams)
        : base(geoSpecieListParams)
    {
        this.SpeciesCode = geoSpecieListParams.SpeciesCode;
    }
#pragma warning restore CS8618

    public GeoSpecieListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeoSpecieListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static GeoSpecieListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["SpeciesCode"] = this.SpeciesCode,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(GeoSpecieListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SpeciesCode?.Equals(other.SpeciesCode) ?? other.SpeciesCode == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/data/nearest/geo/recent/{0}", this.SpeciesCode)
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

    public override int GetHashCode()
    {
        return 0;
    }
}
