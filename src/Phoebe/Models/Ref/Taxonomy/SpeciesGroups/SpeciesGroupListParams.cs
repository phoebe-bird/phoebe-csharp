using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;
using Phoebe.Exceptions;

namespace Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

/// <summary>
/// Get the list of species groups, e.g. terns, finches, etc. #### Notes Merlin puts
/// like birds together, with Falcons next to Hawks, whereas eBird follows taxonomic order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpeciesGroupListParams : ParamsBase
{
    public ApiEnum<string, SpeciesGrouping>? SpeciesGrouping { get; init; }

    /// <summary>
    /// Locale for species group names. English names are returned for any non-listed
    /// locale or any non-translated group name.
    /// </summary>
    public string? GroupNameLocale
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("groupNameLocale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("groupNameLocale", value);
        }
    }

    public SpeciesGroupListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeciesGroupListParams(SpeciesGroupListParams speciesGroupListParams)
        : base(speciesGroupListParams)
    {
        this.SpeciesGrouping = speciesGroupListParams.SpeciesGrouping;
    }
#pragma warning restore CS8618

    public SpeciesGroupListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeciesGroupListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SpeciesGroupListParams FromRawUnchecked(
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
                ["SpeciesGrouping"] = this.SpeciesGrouping,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SpeciesGroupListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.SpeciesGrouping?.Equals(other.SpeciesGrouping) ?? other.SpeciesGrouping == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ref/sppgroup/{0}", this.SpeciesGrouping?.Raw())
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
/// The order in which groups are returned.
/// </summary>
[JsonConverter(typeof(SpeciesGroupingConverter))]
public enum SpeciesGrouping
{
    Merlin,
    Ebird,
}

sealed class SpeciesGroupingConverter : JsonConverter<SpeciesGrouping>
{
    public override SpeciesGrouping Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merlin" => SpeciesGrouping.Merlin,
            "ebird" => SpeciesGrouping.Ebird,
            _ => (SpeciesGrouping)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpeciesGrouping value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpeciesGrouping.Merlin => "merlin",
                SpeciesGrouping.Ebird => "ebird",
                _ => throw new PhoebeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
