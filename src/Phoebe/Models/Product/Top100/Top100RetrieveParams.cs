using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Product.Top100;

/// <summary>
/// Get the top 100 contributors on a given date for a country or region.
///
/// <para>#### Notes</para>
///
/// <para>The results are updated every 15 minutes.</para>
///
/// <para>When ordering by the number of completed checklists, the number of species
/// seen will always be zero. Similarly when ordering by the number of species seen
/// the number of completed checklists will always be zero. &lt;b&gt;Selected Response
/// Field Notes&lt;/b&gt;</para>
///
/// <para>profileHandle - if a user has enabled their profile, this is the handle
/// to reach it via ebird.org/ebird/profile/{profileHandle}</para>
///
/// <para>numSpecies - always zero when checklistSort parameter is true. Invalid
/// observations ARE included in this total numCompleteChecklists - always zero when
/// checklistSort parameter is false</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class Top100RetrieveParams : ParamsBase
{
    public required string RegionCode { get; init; }

    public required long Y { get; init; }

    public required long M { get; init; }

    public long? D { get; init; }

    /// <summary>
    /// Only fetch this number of contributors.
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
    /// Order by number of complete checklists (cl) or by number of species seen (spp).
    /// </summary>
    public ApiEnum<string, RankedBy>? RankedBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, RankedBy>>("rankedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("rankedBy", value);
        }
    }

    public Top100RetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Top100RetrieveParams(Top100RetrieveParams top100RetrieveParams)
        : base(top100RetrieveParams)
    {
        this.RegionCode = top100RetrieveParams.RegionCode;
        this.Y = top100RetrieveParams.Y;
        this.M = top100RetrieveParams.M;
        this.D = top100RetrieveParams.D;
    }
#pragma warning restore CS8618

    public Top100RetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Top100RetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string regionCode,
        long y,
        long m,
        long d
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RegionCode = regionCode;
        this.Y = y;
        this.M = m;
        this.D = d;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static Top100RetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string regionCode,
        long y,
        long m,
        long d
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            regionCode,
            y,
            m,
            d
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

    public virtual bool Equals(Top100RetrieveParams? other)
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
                    "/product/top100/{0}/{1}/{2}/{3}",
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
/// Order by number of complete checklists (cl) or by number of species seen (spp).
/// </summary>
[JsonConverter(typeof(RankedByConverter))]
public enum RankedBy
{
    Spp,
    Cl,
}

sealed class RankedByConverter : JsonConverter<RankedBy>
{
    public override RankedBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "spp" => RankedBy.Spp,
            "cl" => RankedBy.Cl,
            _ => (RankedBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, RankedBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RankedBy.Spp => "spp",
                RankedBy.Cl => "cl",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
