using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Data.Observations.Recent.Notable;

/// <summary>
/// Get the list of recent, notable observations (up to 30 days ago) of birds seen
/// in a country, region or location. Notable observations can be for locally or
/// nationally rare species or are otherwise unusual, e.g. over-wintering birds in
/// a species which is normally only a summer visitor.
/// </summary>
public sealed record class NotableListParams : ParamsBase
{
    public string? RegionCode { get; init; }

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
    /// Include a subset (simple), or all (full), of the fields available.
    /// </summary>
    public ApiEnum<string, Detail>? Detail
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Detail>>(this.RawQueryData, "detail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "detail", value);
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/data/obs/{0}/recent/notable", this.RegionCode)
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
