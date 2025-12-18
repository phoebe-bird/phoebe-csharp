using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Hotspot.Info;

[JsonConverter(typeof(JsonModelConverter<InfoRetrieveResponse, InfoRetrieveResponseFromRaw>))]
public sealed record class InfoRetrieveResponse : JsonModel
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

    public string? CountryName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "countryName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "countryName", value);
        }
    }

    public string? HierarchicalName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "hierarchicalName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "hierarchicalName", value);
        }
    }

    public bool? IsHotspot
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "isHotspot"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "isHotspot", value);
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

    public double? Latitude
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "latitude"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "latitude", value);
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

    public double? Longitude
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "longitude"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "longitude", value);
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

    public string? Subnational1Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subnational1Name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "subnational1Name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.CountryName;
        _ = this.HierarchicalName;
        _ = this.IsHotspot;
        _ = this.Lat;
        _ = this.Latitude;
        _ = this.Lng;
        _ = this.LocID;
        _ = this.LocName;
        _ = this.Longitude;
        _ = this.Name;
        _ = this.Subnational1Code;
        _ = this.Subnational1Name;
    }

    public InfoRetrieveResponse() { }

    public InfoRetrieveResponse(InfoRetrieveResponse infoRetrieveResponse)
        : base(infoRetrieveResponse) { }

    public InfoRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InfoRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InfoRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InfoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InfoRetrieveResponseFromRaw : IFromRawJson<InfoRetrieveResponse>
{
    /// <inheritdoc/>
    public InfoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InfoRetrieveResponse.FromRawUnchecked(rawData);
}
