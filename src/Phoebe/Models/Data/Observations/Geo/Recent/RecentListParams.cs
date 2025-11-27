using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Data.Observations.Geo.Recent;

/// <summary>
/// Get the list of recent observations (up to 30 days ago) of birds seen at locations
/// within a radius of up to 50 kilometers, from a given set of coordinates. Results
/// include only the most recent observation for each species in the region specified.
/// </summary>
public sealed record class RecentListParams : ParamsBase
{
    public required float Lat
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("lat", out JsonElement element))
                throw new PhoebeInvalidDataException(
                    "'lat' cannot be null",
                    new ArgumentOutOfRangeException("lat", "Missing required argument")
                );

            return JsonSerializer.Deserialize<float>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["lat"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required float Lng
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("lng", out JsonElement element))
                throw new PhoebeInvalidDataException(
                    "'lng' cannot be null",
                    new ArgumentOutOfRangeException("lng", "Missing required argument")
                );

            return JsonSerializer.Deserialize<float>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["lng"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    /// Only fetch observations from these taxonomic categories
    /// </summary>
    public ApiEnum<string, Cat>? Cat
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("cat", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Cat>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["cat"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The search radius from the given position, in kilometers.
    /// </summary>
    public long? Dist
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("dist", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["dist"] = JsonSerializer.SerializeToElement(
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
    /// Sort observations by taxonomy or by date, most recent first.
    /// </summary>
    public ApiEnum<string, Sort>? Sort
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("sort", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Sort>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["sort"] = JsonSerializer.SerializeToElement(
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

    public RecentListParams() { }

    public RecentListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecentListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static RecentListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/data/obs/geo/recent")
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

/// <summary>
/// Only fetch observations from these taxonomic categories
/// </summary>
[JsonConverter(typeof(CatConverter))]
public enum Cat
{
    Species,
    Slash,
    Issf,
    Spuh,
    Hybrid,
    Domestic,
    Form,
    Intergrade,
}

sealed class CatConverter : JsonConverter<Cat>
{
    public override Cat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "species" => Cat.Species,
            "slash" => Cat.Slash,
            "issf" => Cat.Issf,
            "spuh" => Cat.Spuh,
            "hybrid" => Cat.Hybrid,
            "domestic" => Cat.Domestic,
            "form" => Cat.Form,
            "intergrade" => Cat.Intergrade,
            _ => (Cat)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cat value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cat.Species => "species",
                Cat.Slash => "slash",
                Cat.Issf => "issf",
                Cat.Spuh => "spuh",
                Cat.Hybrid => "hybrid",
                Cat.Domestic => "domestic",
                Cat.Form => "form",
                Cat.Intergrade => "intergrade",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort observations by taxonomy or by date, most recent first.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    Date,
    Species,
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "date" => Sort.Date,
            "species" => Sort.Species,
            _ => (Sort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sort.Date => "date",
                Sort.Species => "species",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
