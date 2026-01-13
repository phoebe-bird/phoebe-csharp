using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Region.Adjacent;

[JsonConverter(typeof(JsonModelConverter<AdjacentListResponse, AdjacentListResponseFromRaw>))]
public sealed record class AdjacentListResponse : JsonModel
{
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
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
        _ = this.Name;
    }

    public AdjacentListResponse() { }

    public AdjacentListResponse(AdjacentListResponse adjacentListResponse)
        : base(adjacentListResponse) { }

    public AdjacentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdjacentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class AdjacentListResponseFromRaw : IFromRawJson<AdjacentListResponse>
{
    /// <inheritdoc/>
    public AdjacentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AdjacentListResponse.FromRawUnchecked(rawData);
}
