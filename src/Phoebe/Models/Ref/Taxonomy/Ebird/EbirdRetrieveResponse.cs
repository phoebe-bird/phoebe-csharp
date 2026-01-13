using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Taxonomy.Ebird;

[JsonConverter(typeof(JsonModelConverter<EbirdRetrieveResponse, EbirdRetrieveResponseFromRaw>))]
public sealed record class EbirdRetrieveResponse : JsonModel
{
    public IReadOnlyList<string>? BandingCodes
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<string>>("bandingCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "bandingCodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Category
    {
        get { return this._rawData.GetNullableClass<string>("category"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    public string? ComName
    {
        get { return this._rawData.GetNullableClass<string>("comName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("comName", value);
        }
    }

    public IReadOnlyList<string>? ComNameCodes
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<string>>("comNameCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "comNameCodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? FamilyCode
    {
        get { return this._rawData.GetNullableClass<string>("familyCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("familyCode", value);
        }
    }

    public string? FamilyComName
    {
        get { return this._rawData.GetNullableClass<string>("familyComName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("familyComName", value);
        }
    }

    public string? FamilySciName
    {
        get { return this._rawData.GetNullableClass<string>("familySciName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("familySciName", value);
        }
    }

    public string? Order
    {
        get { return this._rawData.GetNullableClass<string>("order"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    public string? SciName
    {
        get { return this._rawData.GetNullableClass<string>("sciName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sciName", value);
        }
    }

    public IReadOnlyList<string>? SciNameCodes
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<string>>("sciNameCodes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "sciNameCodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? SpeciesCode
    {
        get { return this._rawData.GetNullableClass<string>("speciesCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("speciesCode", value);
        }
    }

    public int? TaxonOrder
    {
        get { return this._rawData.GetNullableStruct<int>("taxonOrder"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("taxonOrder", value);
        }
    }

    /// <inheritdoc/>
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

    public EbirdRetrieveResponse(EbirdRetrieveResponse ebirdRetrieveResponse)
        : base(ebirdRetrieveResponse) { }

    public EbirdRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EbirdRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EbirdRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EbirdRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EbirdRetrieveResponseFromRaw : IFromRawJson<EbirdRetrieveResponse>
{
    /// <inheritdoc/>
    public EbirdRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EbirdRetrieveResponse.FromRawUnchecked(rawData);
}
