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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    public double? Lat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("lat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lat", value);
        }
    }

    public string? LatestObsDt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("latestObsDt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latestObsDt", value);
        }
    }

    public double? Lng
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("lng");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lng", value);
        }
    }

    public string? LocID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locId", value);
        }
    }

    public string? LocName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locName", value);
        }
    }

    public int? NumSpeciesAllTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("numSpeciesAllTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numSpeciesAllTime", value);
        }
    }

    public string? Subnational1Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subnational1Code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subnational1Code", value);
        }
    }

    public string? Subnational2Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subnational2Code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subnational2Code", value);
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HotspotListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
