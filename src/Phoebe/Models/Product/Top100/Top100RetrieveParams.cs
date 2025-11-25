using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;
using System = System;

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
/// the number of completed checklists will always be zero. <b>Selected Response Field Notes</b></para>
///
/// <para>profileHandle - if a user has enabled their profile, this is the handle
/// to reach it via ebird.org/ebird/profile/{profileHandle}</para>
///
/// <para>numSpecies - always zero when checklistSort parameter is true. Invalid
/// observations ARE included in this total numCompleteChecklists - always zero when
/// checklistSort parameter is false</para>
/// </summary>
public sealed record class Top100RetrieveParams : ParamsBase
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
    /// Order by number of complete checklists (cl) or by number of species seen (spp).
    /// </summary>
    public ApiEnum<string, RankedBy>? RankedBy
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("rankedBy", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, RankedBy>?>(
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

            this._rawQueryData["rankedBy"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Top100RetrieveParams() { }

    public Top100RetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Top100RetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static Top100RetrieveParams FromRawUnchecked(
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
        System::Type typeToConvert,
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
