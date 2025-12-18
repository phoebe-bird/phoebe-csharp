using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Stats;

[JsonConverter(typeof(JsonModelConverter<StatRetrieveResponse, StatRetrieveResponseFromRaw>))]
public sealed record class StatRetrieveResponse : JsonModel
{
    public int? NumChecklists
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "numChecklists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numChecklists", value);
        }
    }

    public int? NumContributors
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "numContributors"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numContributors", value);
        }
    }

    public int? NumSpecies
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "numSpecies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numSpecies", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumChecklists;
        _ = this.NumContributors;
        _ = this.NumSpecies;
    }

    public StatRetrieveResponse() { }

    public StatRetrieveResponse(StatRetrieveResponse statRetrieveResponse)
        : base(statRetrieveResponse) { }

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

    /// <inheritdoc cref="StatRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static StatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatRetrieveResponseFromRaw : IFromRawJson<StatRetrieveResponse>
{
    /// <inheritdoc/>
    public StatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StatRetrieveResponse.FromRawUnchecked(rawData);
}
