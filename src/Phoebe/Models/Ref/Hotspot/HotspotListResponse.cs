using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Hotspot;

[JsonConverter(typeof(JsonModelConverter<HotspotListResponse, HotspotListResponseFromRaw>))]
public sealed record class HotspotListResponse : JsonModel
{
    public string? CountryCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "countryCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "countryCode", value);
        }
    }

    public double? Lat
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "lat"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "lat", value);
        }
    }

    public string? LatestObsDt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "latestObsDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "latestObsDt", value);
        }
    }

    public double? Lng
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "lng"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "lng", value);
        }
    }

    public string? LocID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "locId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "locId", value);
        }
    }

    public string? LocName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "locName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "locName", value);
        }
    }

    public int? NumSpeciesAllTime
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "numSpeciesAllTime"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numSpeciesAllTime", value);
        }
    }

    public string? Subnational1Code
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subnational1Code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "subnational1Code", value);
        }
    }

    public string? Subnational2Code
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subnational2Code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "subnational2Code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.Lat;
        _ = this.LatestObsDt;
        _ = this.Lng;
        _ = this.LocID;
        _ = this.LocName;
        _ = this.NumSpeciesAllTime;
        _ = this.Subnational1Code;
        _ = this.Subnational2Code;
    }

    public HotspotListResponse() { }

    public HotspotListResponse(HotspotListResponse hotspotListResponse)
        : base(hotspotListResponse) { }

    public HotspotListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HotspotListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HotspotListResponseFromRaw.FromRawUnchecked"/>
    public static HotspotListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HotspotListResponseFromRaw : IFromRawJson<HotspotListResponse>
{
    /// <inheritdoc/>
    public HotspotListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HotspotListResponse.FromRawUnchecked(rawData);
}
