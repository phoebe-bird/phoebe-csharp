using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Checklist;

[JsonConverter(typeof(JsonModelConverter<ChecklistViewResponse, ChecklistViewResponseFromRaw>))]
public sealed record class ChecklistViewResponse : JsonModel
{
    public bool? AllObsReported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allObsReported");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allObsReported", value);
        }
    }

    public string? ChecklistID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checklistId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("checklistId", value);
        }
    }

    public string? CreationDt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creationDt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creationDt", value);
        }
    }

    public double? DurationHrs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationHrs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationHrs", value);
        }
    }

    public string? IsoObsDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("isoObsDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isoObsDate", value);
        }
    }

    public string? LastEditedDt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastEditedDt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastEditedDt", value);
        }
    }

    public Loc? Loc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Loc>("loc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loc", value);
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

    public long? NumObservers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("numObservers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numObservers", value);
        }
    }

    public int? NumSpecies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("numSpecies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numSpecies", value);
        }
    }

    public IReadOnlyList<Ob>? Obs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Ob>>("obs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Ob>?>(
                "obs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public string? ObsTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("obsTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsTime", value);
        }
    }

    public bool? ObsTimeValid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("obsTimeValid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsTimeValid", value);
        }
    }

    public string? ProjID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("projId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("projId", value);
        }
    }

    public string? ProtocolID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("protocolId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protocolId", value);
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

    public string? SubmissionMethodCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("submissionMethodCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("submissionMethodCode", value);
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

    public string? UserDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userDisplayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userDisplayName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllObsReported;
        _ = this.ChecklistID;
        _ = this.CreationDt;
        _ = this.DurationHrs;
        _ = this.IsoObsDate;
        _ = this.LastEditedDt;
        this.Loc?.Validate();
        _ = this.LocID;
        _ = this.NumObservers;
        _ = this.NumSpecies;
        foreach (var item in this.Obs ?? [])
        {
            item.Validate();
        }
        _ = this.ObsDt;
        _ = this.ObsTime;
        _ = this.ObsTimeValid;
        _ = this.ProjID;
        _ = this.ProtocolID;
        _ = this.SubID;
        _ = this.SubmissionMethodCode;
        _ = this.Subnational1Code;
        _ = this.UserDisplayName;
    }

    public ChecklistViewResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChecklistViewResponse(ChecklistViewResponse checklistViewResponse)
        : base(checklistViewResponse) { }
#pragma warning restore CS8618

    public ChecklistViewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChecklistViewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChecklistViewResponseFromRaw.FromRawUnchecked"/>
    public static ChecklistViewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChecklistViewResponseFromRaw : IFromRawJson<ChecklistViewResponse>
{
    /// <inheritdoc/>
    public ChecklistViewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChecklistViewResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Loc, LocFromRaw>))]
public sealed record class Loc : JsonModel
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

    public Loc() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Loc(Loc loc)
        : base(loc) { }
#pragma warning restore CS8618

    public Loc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Loc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocFromRaw.FromRawUnchecked"/>
    public static Loc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocFromRaw : IFromRawJson<Loc>
{
    /// <inheritdoc/>
    public Loc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Loc.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Ob, ObFromRaw>))]
public sealed record class Ob : JsonModel
{
    public IReadOnlyList<ObsAux>? ObsAux
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ObsAux>>("obsAux");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ObsAux>?>(
                "obsAux",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public string? ObsID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("obsId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsId", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ObsAux ?? [])
        {
            item.Validate();
        }
        _ = this.ObsDt;
        _ = this.ObsID;
        _ = this.SpeciesCode;
    }

    public Ob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ob(Ob ob)
        : base(ob) { }
#pragma warning restore CS8618

    public Ob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObFromRaw.FromRawUnchecked"/>
    public static Ob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObFromRaw : IFromRawJson<Ob>
{
    /// <inheritdoc/>
    public Ob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ObsAux, ObsAuxFromRaw>))]
public sealed record class ObsAux : JsonModel
{
    public string? AuxCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auxCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auxCode", value);
        }
    }

    public string? EntryMethodCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entryMethodCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entryMethodCode", value);
        }
    }

    public string? FieldName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fieldName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fieldName", value);
        }
    }

    public string? ObsID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("obsId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("obsId", value);
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

    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuxCode;
        _ = this.EntryMethodCode;
        _ = this.FieldName;
        _ = this.ObsID;
        _ = this.SpeciesCode;
        _ = this.SubID;
        _ = this.Value;
    }

    public ObsAux() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObsAux(ObsAux obsAux)
        : base(obsAux) { }
#pragma warning restore CS8618

    public ObsAux(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObsAux(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObsAuxFromRaw.FromRawUnchecked"/>
    public static ObsAux FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObsAuxFromRaw : IFromRawJson<ObsAux>
{
    /// <inheritdoc/>
    public ObsAux FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ObsAux.FromRawUnchecked(rawData);
}
