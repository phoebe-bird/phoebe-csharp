using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Data.Observations.Recent.Historic;

/// <summary>
/// Get a list of all taxa seen in a country, region or location on a specific date,
/// with the specific observations determined by the "rank" parameter (defaults to
/// latest observation on the date). #### Notes Responses may be cached for 30 minutes
/// </summary>
public sealed record class HistoricListParams : ParamsBase
{
    public required string RegionCode { get; init; }

    public required long Y { get; init; }

    public required long M { get; init; }

    public long? D { get; init; }

    /// <summary>
    /// Only fetch observations from these taxonomic categories
    /// </summary>
    public ApiEnum<string, global::Phoebe.Models.Data.Observations.Recent.Historic.Cat>? Cat
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Phoebe.Models.Data.Observations.Recent.Historic.Cat>
            >(this.RawQueryData, "cat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "cat", value);
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
    /// Include observations which have not yet been reviewed.
    /// </summary>
    public bool? IncludeProvisional
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "includeProvisional"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "includeProvisional", value);
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
    /// Fetch observations from up to 50 locations
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
    /// Include latest observation of the day, or the first added
    /// </summary>
    public ApiEnum<string, Rank>? Rank
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Rank>>(this.RawQueryData, "rank"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "rank", value);
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

    public HistoricListParams() { }

    public HistoricListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoricListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static HistoricListParams FromRawUnchecked(
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
                + string.Format(
                    "/data/obs/{0}/historic/{1}/{2}/{3}",
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
/// Only fetch observations from these taxonomic categories
/// </summary>
[JsonConverter(typeof(global::Phoebe.Models.Data.Observations.Recent.Historic.CatConverter))]
public enum Cat
{
    Species,
    Slash,
    Issf,
    Spuh,
    Hybrid,
    Domestic,
    Form,
    Intergrade,
}

sealed class CatConverter
    : JsonConverter<global::Phoebe.Models.Data.Observations.Recent.Historic.Cat>
{
    public override global::Phoebe.Models.Data.Observations.Recent.Historic.Cat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "species" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Species,
            "slash" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Slash,
            "issf" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Issf,
            "spuh" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Spuh,
            "hybrid" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Hybrid,
            "domestic" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Domestic,
            "form" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Form,
            "intergrade" => global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Intergrade,
            _ => (global::Phoebe.Models.Data.Observations.Recent.Historic.Cat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Phoebe.Models.Data.Observations.Recent.Historic.Cat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Species => "species",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Slash => "slash",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Issf => "issf",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Spuh => "spuh",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Hybrid => "hybrid",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Domestic => "domestic",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Form => "form",
                global::Phoebe.Models.Data.Observations.Recent.Historic.Cat.Intergrade =>
                    "intergrade",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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

/// <summary>
/// Include latest observation of the day, or the first added
/// </summary>
[JsonConverter(typeof(RankConverter))]
public enum Rank
{
    Mrec,
    Create,
}

sealed class RankConverter : JsonConverter<Rank>
{
    public override Rank Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mrec" => Rank.Mrec,
            "create" => Rank.Create,
            _ => (Rank)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Rank value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Rank.Mrec => "mrec",
                Rank.Create => "create",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
