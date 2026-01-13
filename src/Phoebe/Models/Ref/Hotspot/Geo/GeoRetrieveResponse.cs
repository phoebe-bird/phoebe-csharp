using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Hotspot.Geo;

[JsonConverter(typeof(JsonModelConverter<GeoRetrieveResponse, GeoRetrieveResponseFromRaw>))]
public sealed record class GeoRetrieveResponse : JsonModel
{
    public string? CountryCode
    {
        get { return this._rawData.GetNullableClass<string>("countryCode"); }
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
        get { return this._rawData.GetNullableStruct<double>("lat"); }
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
        get { return this._rawData.GetNullableClass<string>("latestObsDt"); }
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
        get { return this._rawData.GetNullableStruct<double>("lng"); }
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
        get { return this._rawData.GetNullableClass<string>("locId"); }
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
        get { return this._rawData.GetNullableClass<string>("locName"); }
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
        get { return this._rawData.GetNullableStruct<int>("numSpeciesAllTime"); }
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
        get { return this._rawData.GetNullableClass<string>("subnational1Code"); }
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
        get { return this._rawData.GetNullableClass<string>("subnational2Code"); }
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

    public GeoRetrieveResponse() { }

    public GeoRetrieveResponse(GeoRetrieveResponse geoRetrieveResponse)
        : base(geoRetrieveResponse) { }

    public GeoRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeoRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeoRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GeoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeoRetrieveResponseFromRaw : IFromRawJson<GeoRetrieveResponse>
{
    /// <inheritdoc/>
    public GeoRetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeoRetrieveResponse.FromRawUnchecked(rawData);
}
