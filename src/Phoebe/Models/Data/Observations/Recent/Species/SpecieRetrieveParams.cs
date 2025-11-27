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
        get
        {
            if (!this._rawQueryData.TryGetValue("back", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["back"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only fetch observations from hotspots
    /// </summary>
    public bool? Hotspot
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("hotspot", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["hotspot"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Include observations which have not yet been reviewed.
    /// </summary>
    public bool? IncludeProvisional
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("includeProvisional", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["includeProvisional"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only fetch this number of observations
    /// </summary>
    public long? MaxResults
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("maxResults", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["maxResults"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Fetch observations from up to 10 locations
    /// </summary>
    public IReadOnlyList<string>? R
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("r", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["r"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Use this language for species common names
    /// </summary>
    public string? SppLocale
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("sppLocale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["sppLocale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
