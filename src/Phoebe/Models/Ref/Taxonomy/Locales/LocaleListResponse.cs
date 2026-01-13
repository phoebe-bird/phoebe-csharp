using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Locales;

[JsonConverter(typeof(JsonModelConverter<LocaleListResponse, LocaleListResponseFromRaw>))]
public sealed record class LocaleListResponse : JsonModel
{
    public string? Code
    {
        get { return this._rawData.GetNullableClass<string>("code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public string? LastUpdated
    {
        get { return this._rawData.GetNullableClass<string>("lastUpdated"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastUpdated", value);
        }
    }

    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.LastUpdated;
        _ = this.Name;
    }

    public LocaleListResponse() { }

    public LocaleListResponse(LocaleListResponse localeListResponse)
        : base(localeListResponse) { }

    public LocaleListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocaleListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocaleListResponseFromRaw.FromRawUnchecked"/>
    public static LocaleListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocaleListResponseFromRaw : IFromRawJson<LocaleListResponse>
{
    /// <inheritdoc/>
    public LocaleListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocaleListResponse.FromRawUnchecked(rawData);
}
