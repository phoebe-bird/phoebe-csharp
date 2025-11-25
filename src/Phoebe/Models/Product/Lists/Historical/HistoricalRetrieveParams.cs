using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;
using System = System;

namespace Phoebe.Models.Product.Lists.Historical;

/// <summary>
/// Get information on the checklists submitted on a given date for a country or region.
/// </summary>
public sealed record class HistoricalRetrieveParams : ParamsBase
{
    public required string RegionCode { get; init; }

    public required long Y { get; init; }

    public required long M { get; init; }

    public long? D { get; init; }

    /// <summary>
    /// Only fetch this number of checklists.
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
    /// Order the results by the date of the checklist or by the date it was submitted.
    /// </summary>
    public ApiEnum<string, SortKey>? SortKey
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("sortKey", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SortKey>?>(
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

            this._rawQueryData["sortKey"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public HistoricalRetrieveParams() { }

    public HistoricalRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoricalRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static HistoricalRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/product/lists/{0}/{1}/{2}/{3}",
                    this.RegionCode,
                    this.Y,
                    this.M,
                    this.D
                )
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
/// Order the results by the date of the checklist or by the date it was submitted.
/// </summary>
[JsonConverter(typeof(SortKeyConverter))]
public enum SortKey
{
    ObsDt,
    CreationDt,
}

sealed class SortKeyConverter : JsonConverter<SortKey>
{
    public override SortKey Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "obs_dt" => SortKey.ObsDt,
            "creation_dt" => SortKey.CreationDt,
            _ => (SortKey)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, SortKey value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortKey.ObsDt => "obs_dt",
                SortKey.CreationDt => "creation_dt",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
