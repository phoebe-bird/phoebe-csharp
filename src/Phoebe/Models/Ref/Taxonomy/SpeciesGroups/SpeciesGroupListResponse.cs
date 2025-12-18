using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

[JsonConverter(
    typeof(JsonModelConverter<SpeciesGroupListResponse, SpeciesGroupListResponseFromRaw>)
)]
public sealed record class SpeciesGroupListResponse : JsonModel
{
    public string? GroupName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "groupName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "groupName", value);
        }
    }

    public long? GroupOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "groupOrder"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "groupOrder", value);
        }
    }

    public IReadOnlyList<List<float>>? TaxonOrderBounds
    {
        get
        {
            return JsonModel.GetNullableClass<List<List<float>>>(this.RawData, "taxonOrderBounds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "taxonOrderBounds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupName;
        _ = this.GroupOrder;
        _ = this.TaxonOrderBounds;
    }

    public SpeciesGroupListResponse() { }

    public SpeciesGroupListResponse(SpeciesGroupListResponse speciesGroupListResponse)
        : base(speciesGroupListResponse) { }

    public SpeciesGroupListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeciesGroupListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpeciesGroupListResponseFromRaw.FromRawUnchecked"/>
    public static SpeciesGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpeciesGroupListResponseFromRaw : IFromRawJson<SpeciesGroupListResponse>
{
    /// <inheritdoc/>
    public SpeciesGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpeciesGroupListResponse.FromRawUnchecked(rawData);
}
