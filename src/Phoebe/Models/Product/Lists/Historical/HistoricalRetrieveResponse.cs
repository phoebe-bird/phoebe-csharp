using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Product.Lists.Historical;

[JsonConverter(
    typeof(JsonModelConverter<HistoricalRetrieveResponse, HistoricalRetrieveResponseFromRaw>)
)]
public sealed record class HistoricalRetrieveResponse : JsonModel
{
    public bool? AllObsReported
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "allObsReported"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allObsReported", value);
        }
    }

    public string? ChecklistID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "checklistId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "checklistId", value);
        }
    }

    public string? CreationDt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "creationDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "creationDt", value);
        }
    }

    public double? DurationHrs
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "durationHrs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "durationHrs", value);
        }
    }

    public string? ISOObsDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "isoObsDate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "isoObsDate", value);
        }
    }

    public string? LastEditedDt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "lastEditedDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "lastEditedDt", value);
        }
    }

    public global::Phoebe.Models.Product.Lists.Historical.Loc? Loc
    {
        get
        {
            return JsonModel.GetNullableClass<global::Phoebe.Models.Product.Lists.Historical.Loc>(
                this.RawData,
                "loc"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "loc", value);
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

    public long? NumObservers
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "numObservers"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numObservers", value);
        }
    }

    public int? NumSpecies
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "numSpecies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "numSpecies", value);
        }
    }

    public IReadOnlyList<global::Phoebe.Models.Product.Lists.Historical.Ob>? Obs
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<global::Phoebe.Models.Product.Lists.Historical.Ob>
            >(this.RawData, "obs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obs", value);
        }
    }

    public string? ObsDt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "obsDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsDt", value);
        }
    }

    public string? ObsTime
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "obsTime"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsTime", value);
        }
    }

    public bool? ObsTimeValid
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "obsTimeValid"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsTimeValid", value);
        }
    }

    public string? ProjID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "projId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "projId", value);
        }
    }

    public string? ProtocolID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "protocolId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "protocolId", value);
        }
    }

    public string? SubID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "subId", value);
        }
    }

    public string? SubmissionMethodCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "submissionMethodCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "submissionMethodCode", value);
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

    public string? UserDisplayName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "userDisplayName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "userDisplayName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllObsReported;
        _ = this.ChecklistID;
        _ = this.CreationDt;
        _ = this.DurationHrs;
        _ = this.ISOObsDate;
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

    public HistoricalRetrieveResponse() { }

    public HistoricalRetrieveResponse(HistoricalRetrieveResponse historicalRetrieveResponse)
        : base(historicalRetrieveResponse) { }

    public HistoricalRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoricalRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoricalRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static HistoricalRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HistoricalRetrieveResponseFromRaw : IFromRawJson<HistoricalRetrieveResponse>
{
    /// <inheritdoc/>
    public HistoricalRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HistoricalRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Phoebe.Models.Product.Lists.Historical.Loc,
        global::Phoebe.Models.Product.Lists.Historical.LocFromRaw
    >)
)]
public sealed record class Loc : JsonModel
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

    public Loc() { }

    public Loc(global::Phoebe.Models.Product.Lists.Historical.Loc loc)
        : base(loc) { }

    public Loc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Loc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Phoebe.Models.Product.Lists.Historical.LocFromRaw.FromRawUnchecked"/>
    public static global::Phoebe.Models.Product.Lists.Historical.Loc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocFromRaw : IFromRawJson<global::Phoebe.Models.Product.Lists.Historical.Loc>
{
    /// <inheritdoc/>
    public global::Phoebe.Models.Product.Lists.Historical.Loc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Phoebe.Models.Product.Lists.Historical.Loc.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Phoebe.Models.Product.Lists.Historical.Ob,
        global::Phoebe.Models.Product.Lists.Historical.ObFromRaw
    >)
)]
public sealed record class Ob : JsonModel
{
    public IReadOnlyList<global::Phoebe.Models.Product.Lists.Historical.ObsAux>? ObsAux
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<global::Phoebe.Models.Product.Lists.Historical.ObsAux>
            >(this.RawData, "obsAux");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsAux", value);
        }
    }

    public string? ObsDt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "obsDt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsDt", value);
        }
    }

    public string? ObsID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "obsId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsId", value);
        }
    }

    public string? SpeciesCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "speciesCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "speciesCode", value);
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

    public Ob(global::Phoebe.Models.Product.Lists.Historical.Ob ob)
        : base(ob) { }

    public Ob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Phoebe.Models.Product.Lists.Historical.ObFromRaw.FromRawUnchecked"/>
    public static global::Phoebe.Models.Product.Lists.Historical.Ob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObFromRaw : IFromRawJson<global::Phoebe.Models.Product.Lists.Historical.Ob>
{
    /// <inheritdoc/>
    public global::Phoebe.Models.Product.Lists.Historical.Ob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Phoebe.Models.Product.Lists.Historical.Ob.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Phoebe.Models.Product.Lists.Historical.ObsAux,
        global::Phoebe.Models.Product.Lists.Historical.ObsAuxFromRaw
    >)
)]
public sealed record class ObsAux : JsonModel
{
    public string? AuxCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "auxCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "auxCode", value);
        }
    }

    public string? EntryMethodCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "entryMethodCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "entryMethodCode", value);
        }
    }

    public string? FieldName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "fieldName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "fieldName", value);
        }
    }

    public string? ObsID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "obsId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "obsId", value);
        }
    }

    public string? SpeciesCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "speciesCode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "speciesCode", value);
        }
    }

    public string? SubID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "subId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "subId", value);
        }
    }

    public string? Value
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "value"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "value", value);
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

    public ObsAux(global::Phoebe.Models.Product.Lists.Historical.ObsAux obsAux)
        : base(obsAux) { }

    public ObsAux(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObsAux(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Phoebe.Models.Product.Lists.Historical.ObsAuxFromRaw.FromRawUnchecked"/>
    public static global::Phoebe.Models.Product.Lists.Historical.ObsAux FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObsAuxFromRaw : IFromRawJson<global::Phoebe.Models.Product.Lists.Historical.ObsAux>
{
    /// <inheritdoc/>
    public global::Phoebe.Models.Product.Lists.Historical.ObsAux FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Phoebe.Models.Product.Lists.Historical.ObsAux.FromRawUnchecked(rawData);
}
