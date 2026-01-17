using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Ref.Region.Info;

/// <summary>
/// Get information on the name and geographical area covered by a region. #### Notes
///
/// <para>Taking Madison County, New York, USA (location code US-NY-053) as an example
/// the various values for the regionNameFormat query parameter work as follows:</para>
///
/// <para>| Value | Description | Result | | ------| ----------- | ------ | | detailed
/// | return a detailed description | Madison County, New York, US | | detailednoqual
/// | return the name to the subnational1 level | Madison, New York | | full | return
/// the full description | Madison, New York, United States | | namequal | return
/// the qualified name | Madison County | | nameonly | return only the name of the
/// region | Madison | | revdetailed | return the detailed description in reverse
/// | US, New York, Madison County |</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InfoRetrieveParams : ParamsBase
{
    public string? RegionCode { get; init; }

    /// <summary>
    /// The characters used to separate elements in the name.
    /// </summary>
    public string? Delim
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("delim");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("delim", value);
        }
    }

    /// <summary>
    /// Control how the name is displayed.
    /// </summary>
    public ApiEnum<string, RegionNameFormat>? RegionNameFormat
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, RegionNameFormat>>(
                "regionNameFormat"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("regionNameFormat", value);
        }
    }

    public InfoRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfoRetrieveParams(InfoRetrieveParams infoRetrieveParams)
        : base(infoRetrieveParams)
    {
        this.RegionCode = infoRetrieveParams.RegionCode;
    }
#pragma warning restore CS8618

    public InfoRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InfoRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InfoRetrieveParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["RegionCode"] = this.RegionCode,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InfoRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RegionCode?.Equals(other.RegionCode) ?? other.RegionCode == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ref/region/info/{0}", this.RegionCode)
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
/// Control how the name is displayed.
/// </summary>
[JsonConverter(typeof(RegionNameFormatConverter))]
public enum RegionNameFormat
{
    Detailed,
    Detailednoqual,
    Full,
    Namequal,
    Nameonly,
    Revdetailed,
}

sealed class RegionNameFormatConverter : JsonConverter<RegionNameFormat>
{
    public override RegionNameFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "detailed" => RegionNameFormat.Detailed,
            "detailednoqual" => RegionNameFormat.Detailednoqual,
            "full" => RegionNameFormat.Full,
            "namequal" => RegionNameFormat.Namequal,
            "nameonly" => RegionNameFormat.Nameonly,
            "revdetailed" => RegionNameFormat.Revdetailed,
            _ => (RegionNameFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegionNameFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegionNameFormat.Detailed => "detailed",
                RegionNameFormat.Detailednoqual => "detailednoqual",
                RegionNameFormat.Full => "full",
                RegionNameFormat.Namequal => "namequal",
                RegionNameFormat.Nameonly => "nameonly",
                RegionNameFormat.Revdetailed => "revdetailed",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
