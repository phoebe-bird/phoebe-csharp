using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionListResponse, VersionListResponseFromRaw>))]
public sealed record class VersionListResponse : JsonModel
{
    public double? AuthorityVer
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "authorityVer"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "authorityVer", value);
        }
    }

    public bool? Latest
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "latest"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "latest", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorityVer;
        _ = this.Latest;
    }

    public VersionListResponse() { }

    public VersionListResponse(VersionListResponse versionListResponse)
        : base(versionListResponse) { }

    public VersionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionListResponseFromRaw.FromRawUnchecked"/>
    public static VersionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionListResponseFromRaw : IFromRawJson<VersionListResponse>
{
    /// <inheritdoc/>
    public VersionListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionListResponse.FromRawUnchecked(rawData);
}
