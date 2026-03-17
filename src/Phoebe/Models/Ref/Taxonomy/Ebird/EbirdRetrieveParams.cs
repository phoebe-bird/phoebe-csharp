using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Ref.Taxonomy.Ebird;

/// <summary>
/// Get the taxonomy used by eBird. #### Notes Each entry in the taxonomy contains
/// a species code for example, barswa for Barn Swallow. You can download the taxonomy
/// for selected species using the *species* query parameter with a comma separating
/// each code. Otherwise the full taxonomy is downloaded.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EbirdRetrieveParams : ParamsBase
{
    /// <summary>
    /// Only fetch records from these taxonomic categories.
    /// </summary>
    public string? Cat
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cat", value);
        }
    }

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

    /// <summary>
    /// Use this language for common names.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("locale", value);
        }
    }

    /// <summary>
    /// Only fetch records for these species.
    /// </summary>
    public string? Species
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("species");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("species", value);
        }
    }

    /// <summary>
    /// Fetch a specific version of the taxonomy.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("version", value);
        }
    }

    public EbirdRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EbirdRetrieveParams(EbirdRetrieveParams ebirdRetrieveParams)
        : base(ebirdRetrieveParams) { }
#pragma warning restore CS8618

    public EbirdRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EbirdRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EbirdRetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(EbirdRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ref/taxonomy/ebird")
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
