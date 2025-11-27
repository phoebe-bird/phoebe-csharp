using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Ref.Hotspot.Geo;

/// <summary>
/// Get the list of hotspots, within a radius of up to 50 kilometers, from a given
/// set of coordinates.
/// </summary>
public sealed record class GeoRetrieveParams : ParamsBase
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
    /// The number of days back to fetch hotspots.
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
    /// Fetch the records in CSV or JSON format.
    /// </summary>
    public ApiEnum<string, global::Phoebe.Models.Ref.Hotspot.Geo.Fmt>? Fmt
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("fmt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Phoebe.Models.Ref.Hotspot.Geo.Fmt
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["fmt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public GeoRetrieveParams() { }

    public GeoRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeoRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static GeoRetrieveParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ref/hotspot/geo")
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
/// Fetch the records in CSV or JSON format.
/// </summary>
[JsonConverter(typeof(global::Phoebe.Models.Ref.Hotspot.Geo.FmtConverter))]
public enum Fmt
{
    Csv,
    Json,
}

sealed class FmtConverter : JsonConverter<global::Phoebe.Models.Ref.Hotspot.Geo.Fmt>
{
    public override global::Phoebe.Models.Ref.Hotspot.Geo.Fmt Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => global::Phoebe.Models.Ref.Hotspot.Geo.Fmt.Csv,
            "json" => global::Phoebe.Models.Ref.Hotspot.Geo.Fmt.Json,
            _ => (global::Phoebe.Models.Ref.Hotspot.Geo.Fmt)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Phoebe.Models.Ref.Hotspot.Geo.Fmt value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Phoebe.Models.Ref.Hotspot.Geo.Fmt.Csv => "csv",
                global::Phoebe.Models.Ref.Hotspot.Geo.Fmt.Json => "json",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
