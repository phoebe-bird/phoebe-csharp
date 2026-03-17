using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Ref.Region.List;

/// <summary>
/// Get the list of sub-regions for a given country or region. #### Notes Not all
/// combinations of region type and region code are valid. You can fetch all the subnational1
/// or subnational2 regions for a country however you can only specify a region type
/// of 'country' when using 'world' as a region code.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ListListParams : ParamsBase
{
    public required string RegionType { get; init; }

    public string? ParentRegionCode { get; init; }

    /// <summary>
    /// Fetch the records in CSV or JSON format.
    /// </summary>
    public ApiEnum<string, Fmt>? Fmt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Fmt>>("fmt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fmt", value);
        }
    }

    public ListListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListListParams(ListListParams listListParams)
        : base(listListParams)
    {
        this.RegionType = listListParams.RegionType;
        this.ParentRegionCode = listListParams.ParentRegionCode;
    }
#pragma warning restore CS8618

    public ListListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ListListParams FromRawUnchecked(
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
                    ["RegionType"] = JsonSerializer.SerializeToElement(this.RegionType),
                    ["ParentRegionCode"] = JsonSerializer.SerializeToElement(this.ParentRegionCode),
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

    public virtual bool Equals(ListListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RegionType.Equals(other.RegionType)
            && (
                this.ParentRegionCode?.Equals(other.ParentRegionCode)
                ?? other.ParentRegionCode == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ref/region/list/{0}/{1}", this.RegionType, this.ParentRegionCode)
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
/// Fetch the records in CSV or JSON format.
/// </summary>
[JsonConverter(typeof(FmtConverter))]
public enum Fmt
{
    Csv,
    Json,
}

sealed class FmtConverter : JsonConverter<Fmt>
{
    public override Fmt Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => Fmt.Csv,
            "json" => Fmt.Json,
            _ => (Fmt)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Fmt value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Fmt.Csv => "csv",
                Fmt.Json => "json",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
