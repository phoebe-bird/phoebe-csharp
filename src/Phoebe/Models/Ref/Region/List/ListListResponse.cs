using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Region.List;

[JsonConverter(typeof(JsonModelConverter<ListListResponse, ListListResponseFromRaw>))]
public sealed record class ListListResponse : JsonModel
{
    public string? Code
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "code", value);
        }
    }

    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
    }

    public ListListResponse() { }

    public ListListResponse(ListListResponse listListResponse)
        : base(listListResponse) { }

    public ListListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListListResponseFromRaw.FromRawUnchecked"/>
    public static ListListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListListResponseFromRaw : IFromRawJson<ListListResponse>
{
    /// <inheritdoc/>
    public ListListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListListResponse.FromRawUnchecked(rawData);
}
