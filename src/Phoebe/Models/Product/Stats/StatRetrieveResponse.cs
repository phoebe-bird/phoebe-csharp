using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Stats;

[JsonConverter(typeof(ModelConverter<StatRetrieveResponse, StatRetrieveResponseFromRaw>))]
public sealed record class StatRetrieveResponse : ModelBase
{
    public int? NumChecklists
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "numChecklists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "numChecklists", value);
        }
    }

    public int? NumContributors
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "numContributors"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "numContributors", value);
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

    public override void Validate()
    {
        _ = this.NumChecklists;
        _ = this.NumContributors;
        _ = this.NumSpecies;
    }

    public StatRetrieveResponse() { }

    public StatRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StatRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static StatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatRetrieveResponseFromRaw : IFromRaw<StatRetrieveResponse>
{
    public StatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StatRetrieveResponse.FromRawUnchecked(rawData);
}
