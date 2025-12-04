using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Versions;

[JsonConverter(typeof(ModelConverter<VersionListResponse, VersionListResponseFromRaw>))]
public sealed record class VersionListResponse : ModelBase
{
    public double? AuthorityVer
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "authorityVer"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "authorityVer", value);
        }
    }

    public bool? Latest
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "latest"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "latest", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorityVer;
        _ = this.Latest;
    }

    public VersionListResponse() { }

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

class VersionListResponseFromRaw : IFromRaw<VersionListResponse>
{
    /// <inheritdoc/>
    public VersionListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionListResponse.FromRawUnchecked(rawData);
}
