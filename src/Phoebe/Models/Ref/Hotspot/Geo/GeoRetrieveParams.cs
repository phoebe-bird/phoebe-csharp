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
        get { return ModelBase.GetNotNullStruct<float>(this.RawQueryData, "lat"); }
        init { ModelBase.Set(this._rawQueryData, "lat", value); }
    }

    public required float Lng
    {
        get { return ModelBase.GetNotNullStruct<float>(this.RawQueryData, "lng"); }
        init { ModelBase.Set(this._rawQueryData, "lng", value); }
    }

    /// <summary>
    /// The number of days back to fetch hotspots.
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
    /// The search radius from the given position, in kilometers.
    /// </summary>
    public long? Dist
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "dist"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "dist", value);
        }
    }

    /// <summary>
    /// Fetch the records in CSV or JSON format.
    /// </summary>
    public ApiEnum<string, global::Phoebe.Models.Ref.Hotspot.Geo.Fmt>? Fmt
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Phoebe.Models.Ref.Hotspot.Geo.Fmt>
            >(this.RawQueryData, "fmt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "fmt", value);
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
