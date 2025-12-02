using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Top100;

[JsonConverter(typeof(ModelConverter<Top100RetrieveResponse, Top100RetrieveResponseFromRaw>))]
public sealed record class Top100RetrieveResponse : ModelBase
{
    public int? NumCompleteChecklists
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "numCompleteChecklists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "numCompleteChecklists", value);
        }
    }

    public int? NumSpecies
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "numSpecies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "numSpecies", value);
        }
    }

    public string? ProfileHandle
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "profileHandle"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "profileHandle", value);
        }
    }

    public int? RowNum
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "rowNum"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "rowNum", value);
        }
    }

    public string? UserDisplayName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "userDisplayName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "userDisplayName", value);
        }
    }

    public string? UserID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "userId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "userId", value);
        }
    }

    public override void Validate()
    {
        _ = this.NumCompleteChecklists;
        _ = this.NumSpecies;
        _ = this.ProfileHandle;
        _ = this.RowNum;
        _ = this.UserDisplayName;
        _ = this.UserID;
    }

    public Top100RetrieveResponse() { }

    public Top100RetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Top100RetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Top100RetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Top100RetrieveResponseFromRaw : IFromRaw<Top100RetrieveResponse>
{
    public Top100RetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Top100RetrieveResponse.FromRawUnchecked(rawData);
}
