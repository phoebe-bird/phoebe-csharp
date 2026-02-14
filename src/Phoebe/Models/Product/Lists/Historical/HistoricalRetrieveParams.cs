using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Product.Lists.Historical;

/// <summary>
/// Get information on the checklists submitted on a given date for a country or region.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class HistoricalRetrieveParams : ParamsBase
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
    /// Order the results by the date of the checklist or by the date it was submitted.
    /// </summary>
    public ApiEnum<string, SortKey>? SortKey
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortKey>>("sortKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sortKey", value);
        }
    }

    public HistoricalRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoricalRetrieveParams(HistoricalRetrieveParams historicalRetrieveParams)
        : base(historicalRetrieveParams)
    {
        this.RegionCode = historicalRetrieveParams.RegionCode;
        this.Y = historicalRetrieveParams.Y;
        this.M = historicalRetrieveParams.M;
        this.D = historicalRetrieveParams.D;
    }
#pragma warning restore CS8618

    public HistoricalRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoricalRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RegionCode"] = JsonSerializer.SerializeToElement(this.RegionCode),
                    ["Y"] = JsonSerializer.SerializeToElement(this.Y),
                    ["M"] = JsonSerializer.SerializeToElement(this.M),
                    ["D"] = JsonSerializer.SerializeToElement(this.D),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(HistoricalRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RegionCode.Equals(other.RegionCode)
            && this.Y.Equals(other.Y)
            && this.M.Equals(other.M)
            && (this.D?.Equals(other.D) ?? other.D == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
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

    public override int GetHashCode()
    {
        return 0;
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
        Type typeToConvert,
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
