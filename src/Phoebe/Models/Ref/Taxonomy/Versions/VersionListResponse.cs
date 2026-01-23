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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("authorityVer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorityVer", value);
        }
    }

    public bool? Latest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("latest");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latest", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorityVer;
        _ = this.Latest;
    }

    public VersionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionListResponse(VersionListResponse versionListResponse)
        : base(versionListResponse) { }
#pragma warning restore CS8618

    public VersionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
