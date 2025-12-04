using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Region.Adjacent;

[JsonConverter(typeof(ModelConverter<AdjacentListResponse, AdjacentListResponseFromRaw>))]
public sealed record class AdjacentListResponse : ModelBase
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
    }

    public AdjacentListResponse() { }

    public AdjacentListResponse(AdjacentListResponse adjacentListResponse)
        : base(adjacentListResponse) { }

    public AdjacentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdjacentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdjacentListResponseFromRaw.FromRawUnchecked"/>
    public static AdjacentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdjacentListResponseFromRaw : IFromRaw<AdjacentListResponse>
{
    /// <inheritdoc/>
    public AdjacentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AdjacentListResponse.FromRawUnchecked(rawData);
}
