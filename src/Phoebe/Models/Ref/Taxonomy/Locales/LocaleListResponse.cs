using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Locales;

[JsonConverter(typeof(ModelConverter<LocaleListResponse, LocaleListResponseFromRaw>))]
public sealed record class LocaleListResponse : ModelBase
{
    public string? Code
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "code", value);
        }
    }

    public string? LastUpdated
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "lastUpdated"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "lastUpdated", value);
        }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    public override void Validate()
    {
        _ = this.Code;
        _ = this.LastUpdated;
        _ = this.Name;
    }

    public LocaleListResponse() { }

    public LocaleListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocaleListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LocaleListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocaleListResponseFromRaw : IFromRaw<LocaleListResponse>
{
    public LocaleListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocaleListResponse.FromRawUnchecked(rawData);
}
