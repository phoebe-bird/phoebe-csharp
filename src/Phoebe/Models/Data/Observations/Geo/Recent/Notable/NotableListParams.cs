using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Data.Observations.Geo.Recent.Notable;

/// <summary>
/// Get the list of notable observations (up to 30 days ago) of birds seen at locations
/// within a radius of up to 50 kilometers, from a given set of coordinates. Notable
/// observations can be for locally or nationally rare species or are otherwise unusual,
/// for example over-wintering birds in a species which is normally only a summer visitor.
/// </summary>
public sealed record class NotableListParams : ParamsBase
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
    /// Include a subset (simple), or all (full), of the fields available.
    /// </summary>
    public ApiEnum<string, Detail>? Detail
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("detail", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Detail>?>(
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

            this._rawQueryData["detail"] = JsonSerializer.SerializeToElement(
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

    public NotableListParams() { }

    public NotableListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotableListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static NotableListParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/data/obs/geo/recent/notable"
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

/// <summary>
/// Include a subset (simple), or all (full), of the fields available.
/// </summary>
[JsonConverter(typeof(DetailConverter))]
public enum Detail
{
    Simple,
    Full,
}

sealed class DetailConverter : JsonConverter<Detail>
{
    public override Detail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "simple" => Detail.Simple,
            "full" => Detail.Full,
            _ => (Detail)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Detail value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Detail.Simple => "simple",
                Detail.Full => "full",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
