using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

[JsonConverter(typeof(ModelConverter<SpeciesGroupListResponse, SpeciesGroupListResponseFromRaw>))]
public sealed record class SpeciesGroupListResponse : ModelBase
{
    public string? GroupName
    {
        get
        {
            if (!this._rawData.TryGetValue("groupName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["groupName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? GroupOrder
    {
        get
        {
            if (!this._rawData.TryGetValue("groupOrder", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["groupOrder"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<List<float>>? TaxonOrderBounds
    {
        get
        {
            if (!this._rawData.TryGetValue("taxonOrderBounds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<List<float>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["taxonOrderBounds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupName;
        _ = this.GroupOrder;
        _ = this.TaxonOrderBounds;
    }

    public SpeciesGroupListResponse() { }

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

    public static SpeciesGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpeciesGroupListResponseFromRaw : IFromRaw<SpeciesGroupListResponse>
{
    public SpeciesGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpeciesGroupListResponse.FromRawUnchecked(rawData);
}
