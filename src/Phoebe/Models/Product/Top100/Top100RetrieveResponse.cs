using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Top100;

[JsonConverter(typeof(JsonModelConverter<Top100RetrieveResponse, Top100RetrieveResponseFromRaw>))]
public sealed record class Top100RetrieveResponse : JsonModel
{
    public int? NumCompleteChecklists
    {
        get { return this._rawData.GetNullableStruct<int>("numCompleteChecklists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numCompleteChecklists", value);
        }
    }

    public int? NumSpecies
    {
        get { return this._rawData.GetNullableStruct<int>("numSpecies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numSpecies", value);
        }
    }

    public string? ProfileHandle
    {
        get { return this._rawData.GetNullableClass<string>("profileHandle"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileHandle", value);
        }
    }

    public int? RowNum
    {
        get { return this._rawData.GetNullableStruct<int>("rowNum"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rowNum", value);
        }
    }

    public string? UserDisplayName
    {
        get { return this._rawData.GetNullableClass<string>("userDisplayName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userDisplayName", value);
        }
    }

    public string? UserID
    {
        get { return this._rawData.GetNullableClass<string>("userId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userId", value);
        }
    }

    /// <inheritdoc/>
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

    public Top100RetrieveResponse(Top100RetrieveResponse top100RetrieveResponse)
        : base(top100RetrieveResponse) { }

    public Top100RetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Top100RetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Top100RetrieveResponseFromRaw.FromRawUnchecked"/>
    public static Top100RetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Top100RetrieveResponseFromRaw : IFromRawJson<Top100RetrieveResponse>
{
    /// <inheritdoc/>
    public Top100RetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Top100RetrieveResponse.FromRawUnchecked(rawData);
}
