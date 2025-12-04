using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Data.Observations;

[JsonConverter(typeof(ModelConverter<Observation, ObservationFromRaw>))]
public sealed record class Observation : ModelBase
{
    public long? ID
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
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

    public string? Firstname
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "firstname"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "firstname", value);
        }
    }

    public long? HowMany
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "howMany"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "howMany", value);
        }
    }

    public string? Lastname
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "lastname"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "lastname", value);
        }
    }

    public float? Lat
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "lat"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "lat", value);
        }
    }

    public float? Lng
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "lng"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "lng", value);
        }
    }

    public bool? LocationPrivate
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "locationPrivate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "locationPrivate", value);
        }
    }

    public string? LocID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "locId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "locId", value);
        }
    }

    public string? LocName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "locName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "locName", value);
        }
    }

    public string? ObsDt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "obsDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "obsDt", value);
        }
    }

    public bool? ObsReviewed
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "obsReviewed"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "obsReviewed", value);
        }
    }

    public bool? ObsValid
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "obsValid"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "obsValid", value);
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

    public string? SubID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "subId", value);
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

    public Observation(Observation observation)
        : base(observation) { }

    public Observation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Observation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObservationFromRaw.FromRawUnchecked"/>
    public static Observation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObservationFromRaw : IFromRaw<Observation>
{
    /// <inheritdoc/>
    public Observation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Observation.FromRawUnchecked(rawData);
}
