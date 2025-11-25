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
        get
        {
            if (!this._rawData.TryGetValue("authorityVer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["authorityVer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Latest
    {
        get
        {
            if (!this._rawData.TryGetValue("latest", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["latest"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static VersionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionListResponseFromRaw : IFromRaw<VersionListResponse>
{
    public VersionListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionListResponse.FromRawUnchecked(rawData);
}
