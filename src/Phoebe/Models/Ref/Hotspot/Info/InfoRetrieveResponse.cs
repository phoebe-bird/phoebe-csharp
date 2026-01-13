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

    public string? CountryName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryName", value);
        }
    }

    public string? HierarchicalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hierarchicalName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hierarchicalName", value);
        }
    }

    public bool? IsHotspot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isHotspot");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isHotspot", value);
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

    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latitude", value);
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

    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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

    public string? Subnational1Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subnational1Name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subnational1Name", value);
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InfoRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
