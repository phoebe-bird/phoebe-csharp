using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("groupName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("groupName", value);
        }
    }

    public long? GroupOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("groupOrder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("groupOrder", value);
        }
    }

    public IReadOnlyList<IReadOnlyList<float>>? TaxonOrderBounds
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<float>>>(
                "taxonOrderBounds"
            );
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<float>)item)
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<float>>?>(
                "taxonOrderBounds",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeciesGroupListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
