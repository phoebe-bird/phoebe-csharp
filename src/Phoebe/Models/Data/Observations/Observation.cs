using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Data.Observations;

[JsonConverter(typeof(JsonModelConverter<Observation, ObservationFromRaw>))]
public sealed record class Observation : JsonModel
{
    public long? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? ComName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("comName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("comName", value);
        }
    }

    public string? Firstname
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("firstname");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("firstname", value);
        }
    }

    public long? HowMany
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("howMany");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("howMany", value);
        }
    }

    public string? Lastname
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastname");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastname", value);
        }
    }

    public float? Lat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("lat");
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

    public float? Lng
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("lng");
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

    public bool? LocationPrivate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("locationPrivate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locationPrivate", value);
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

    public string? ObsDt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("obsDt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsDt", value);
        }
    }

    public bool? ObsReviewed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("obsReviewed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsReviewed", value);
        }
    }

    public bool? ObsValid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("obsValid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsValid", value);
        }
    }

    public string? SciName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sciName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sciName", value);
        }
    }

    public string? SpeciesCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("speciesCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("speciesCode", value);
        }
    }

    public string? SubID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ComName;
        _ = this.Firstname;
        _ = this.HowMany;
        _ = this.Lastname;
        _ = this.Lat;
        _ = this.Lng;
        _ = this.LocationPrivate;
        _ = this.LocID;
        _ = this.LocName;
        _ = this.ObsDt;
        _ = this.ObsReviewed;
        _ = this.ObsValid;
        _ = this.SciName;
        _ = this.SpeciesCode;
        _ = this.SubID;
    }

    public Observation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Observation(Observation observation)
        : base(observation) { }
#pragma warning restore CS8618

    public Observation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Observation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObservationFromRaw.FromRawUnchecked"/>
    public static Observation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObservationFromRaw : IFromRawJson<Observation>
{
    /// <inheritdoc/>
    public Observation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Observation.FromRawUnchecked(rawData);
}
