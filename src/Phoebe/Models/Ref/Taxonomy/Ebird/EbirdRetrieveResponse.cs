using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Ebird;

[JsonConverter(typeof(ModelConverter<EbirdRetrieveResponse, EbirdRetrieveResponseFromRaw>))]
public sealed record class EbirdRetrieveResponse : ModelBase
{
    public IReadOnlyList<string>? BandingCodes
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "bandingCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "bandingCodes", value);
        }
    }

    public string? Category
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "category"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "category", value);
        }
    }

    public string? ComName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "comName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "comName", value);
        }
    }

    public IReadOnlyList<string>? ComNameCodes
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "comNameCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "comNameCodes", value);
        }
    }

    public string? FamilyCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "familyCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "familyCode", value);
        }
    }

    public string? FamilyComName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "familyComName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "familyComName", value);
        }
    }

    public string? FamilySciName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "familySciName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "familySciName", value);
        }
    }

    public string? Order
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "order"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "order", value);
        }
    }

    public string? SciName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "sciName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "sciName", value);
        }
    }

    public IReadOnlyList<string>? SciNameCodes
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "sciNameCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "sciNameCodes", value);
        }
    }

    public string? SpeciesCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "speciesCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "speciesCode", value);
        }
    }

    public int? TaxonOrder
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "taxonOrder"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "taxonOrder", value);
        }
    }

    public override void Validate()
    {
        _ = this.BandingCodes;
        _ = this.Category;
        _ = this.ComName;
        _ = this.ComNameCodes;
        _ = this.FamilyCode;
        _ = this.FamilyComName;
        _ = this.FamilySciName;
        _ = this.Order;
        _ = this.SciName;
        _ = this.SciNameCodes;
        _ = this.SpeciesCode;
        _ = this.TaxonOrder;
    }

    public EbirdRetrieveResponse() { }

    public EbirdRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EbirdRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static EbirdRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EbirdRetrieveResponseFromRaw : IFromRaw<EbirdRetrieveResponse>
{
    public EbirdRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EbirdRetrieveResponse.FromRawUnchecked(rawData);
}
