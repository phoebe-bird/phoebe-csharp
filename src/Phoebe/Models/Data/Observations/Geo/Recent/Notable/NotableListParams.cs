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
    /// Include a subset (simple), or all (full), of the fields available.
    /// </summary>
    public ApiEnum<string, Detail>? Detail
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Detail>>("detail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("detail", value);
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

    public NotableListParams() { }

    public NotableListParams(NotableListParams notableListParams)
        : base(notableListParams) { }

    public NotableListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotableListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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
