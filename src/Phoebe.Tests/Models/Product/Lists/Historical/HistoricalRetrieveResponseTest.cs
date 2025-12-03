using System.Collections.Generic;
using System.Text.Json;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Tests.Models.Product.Lists.Historical;

public class HistoricalRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            AllObsReported = true,
            ChecklistID = "checklistId",
            CreationDt = "creationDt",
            DurationHrs = 0,
            ISOObsDate = "isoObsDate",
            LastEditedDt = "lastEditedDt",
            Loc = new()
            {
                CountryCode = "countryCode",
                CountryName = "countryName",
                HierarchicalName = "hierarchicalName",
                IsHotspot = true,
                Lat = 0,
                Latitude = 0,
                Lng = 0,
                LocID = "locId",
                LocName = "locName",
                Longitude = 0,
                Name = "name",
                Subnational1Code = "subnational1Code",
                Subnational1Name = "subnational1Name",
            },
            LocID = "locId",
            NumObservers = 0,
            NumSpecies = 0,
            Obs =
            [
                new()
                {
                    ObsAux =
                    [
                        new()
                        {
                            AuxCode = "auxCode",
                            EntryMethodCode = "entryMethodCode",
                            FieldName = "fieldName",
                            ObsID = "obsId",
                            SpeciesCode = "speciesCode",
                            SubID = "subId",
                            Value = "value",
                        },
                    ],
                    ObsDt = "obsDt",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                },
            ],
            ObsDt = "obsDt",
            ObsTime = "obsTime",
            ObsTimeValid = true,
            ProjID = "projId",
            ProtocolID = "protocolId",
            SubID = "subId",
            SubmissionMethodCode = "submissionMethodCode",
            Subnational1Code = "subnational1Code",
            UserDisplayName = "userDisplayName",
        };

        bool expectedAllObsReported = true;
        string expectedChecklistID = "checklistId";
        string expectedCreationDt = "creationDt";
        double expectedDurationHrs = 0;
        string expectedISOObsDate = "isoObsDate";
        string expectedLastEditedDt = "lastEditedDt";
        Loc expectedLoc = new()
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };
        string expectedLocID = "locId";
        long expectedNumObservers = 0;
        int expectedNumSpecies = 0;
        List<Ob> expectedObs =
        [
            new()
            {
                ObsAux =
                [
                    new()
                    {
                        AuxCode = "auxCode",
                        EntryMethodCode = "entryMethodCode",
                        FieldName = "fieldName",
                        ObsID = "obsId",
                        SpeciesCode = "speciesCode",
                        SubID = "subId",
                        Value = "value",
                    },
                ],
                ObsDt = "obsDt",
                ObsID = "obsId",
                SpeciesCode = "speciesCode",
            },
        ];
        string expectedObsDt = "obsDt";
        string expectedObsTime = "obsTime";
        bool expectedObsTimeValid = true;
        string expectedProjID = "projId";
        string expectedProtocolID = "protocolId";
        string expectedSubID = "subId";
        string expectedSubmissionMethodCode = "submissionMethodCode";
        string expectedSubnational1Code = "subnational1Code";
        string expectedUserDisplayName = "userDisplayName";

        Assert.Equal(expectedAllObsReported, model.AllObsReported);
        Assert.Equal(expectedChecklistID, model.ChecklistID);
        Assert.Equal(expectedCreationDt, model.CreationDt);
        Assert.Equal(expectedDurationHrs, model.DurationHrs);
        Assert.Equal(expectedISOObsDate, model.ISOObsDate);
        Assert.Equal(expectedLastEditedDt, model.LastEditedDt);
        Assert.Equal(expectedLoc, model.Loc);
        Assert.Equal(expectedLocID, model.LocID);
        Assert.Equal(expectedNumObservers, model.NumObservers);
        Assert.Equal(expectedNumSpecies, model.NumSpecies);
        Assert.Equal(expectedObs.Count, model.Obs.Count);
        for (int i = 0; i < expectedObs.Count; i++)
        {
            Assert.Equal(expectedObs[i], model.Obs[i]);
        }
        Assert.Equal(expectedObsDt, model.ObsDt);
        Assert.Equal(expectedObsTime, model.ObsTime);
        Assert.Equal(expectedObsTimeValid, model.ObsTimeValid);
        Assert.Equal(expectedProjID, model.ProjID);
        Assert.Equal(expectedProtocolID, model.ProtocolID);
        Assert.Equal(expectedSubID, model.SubID);
        Assert.Equal(expectedSubmissionMethodCode, model.SubmissionMethodCode);
        Assert.Equal(expectedSubnational1Code, model.Subnational1Code);
        Assert.Equal(expectedUserDisplayName, model.UserDisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            AllObsReported = true,
            ChecklistID = "checklistId",
            CreationDt = "creationDt",
            DurationHrs = 0,
            ISOObsDate = "isoObsDate",
            LastEditedDt = "lastEditedDt",
            Loc = new()
            {
                CountryCode = "countryCode",
                CountryName = "countryName",
                HierarchicalName = "hierarchicalName",
                IsHotspot = true,
                Lat = 0,
                Latitude = 0,
                Lng = 0,
                LocID = "locId",
                LocName = "locName",
                Longitude = 0,
                Name = "name",
                Subnational1Code = "subnational1Code",
                Subnational1Name = "subnational1Name",
            },
            LocID = "locId",
            NumObservers = 0,
            NumSpecies = 0,
            Obs =
            [
                new()
                {
                    ObsAux =
                    [
                        new()
                        {
                            AuxCode = "auxCode",
                            EntryMethodCode = "entryMethodCode",
                            FieldName = "fieldName",
                            ObsID = "obsId",
                            SpeciesCode = "speciesCode",
                            SubID = "subId",
                            Value = "value",
                        },
                    ],
                    ObsDt = "obsDt",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                },
            ],
            ObsDt = "obsDt",
            ObsTime = "obsTime",
            ObsTimeValid = true,
            ProjID = "projId",
            ProtocolID = "protocolId",
            SubID = "subId",
            SubmissionMethodCode = "submissionMethodCode",
            Subnational1Code = "subnational1Code",
            UserDisplayName = "userDisplayName",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HistoricalRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            AllObsReported = true,
            ChecklistID = "checklistId",
            CreationDt = "creationDt",
            DurationHrs = 0,
            ISOObsDate = "isoObsDate",
            LastEditedDt = "lastEditedDt",
            Loc = new()
            {
                CountryCode = "countryCode",
                CountryName = "countryName",
                HierarchicalName = "hierarchicalName",
                IsHotspot = true,
                Lat = 0,
                Latitude = 0,
                Lng = 0,
                LocID = "locId",
                LocName = "locName",
                Longitude = 0,
                Name = "name",
                Subnational1Code = "subnational1Code",
                Subnational1Name = "subnational1Name",
            },
            LocID = "locId",
            NumObservers = 0,
            NumSpecies = 0,
            Obs =
            [
                new()
                {
                    ObsAux =
                    [
                        new()
                        {
                            AuxCode = "auxCode",
                            EntryMethodCode = "entryMethodCode",
                            FieldName = "fieldName",
                            ObsID = "obsId",
                            SpeciesCode = "speciesCode",
                            SubID = "subId",
                            Value = "value",
                        },
                    ],
                    ObsDt = "obsDt",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                },
            ],
            ObsDt = "obsDt",
            ObsTime = "obsTime",
            ObsTimeValid = true,
            ProjID = "projId",
            ProtocolID = "protocolId",
            SubID = "subId",
            SubmissionMethodCode = "submissionMethodCode",
            Subnational1Code = "subnational1Code",
            UserDisplayName = "userDisplayName",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HistoricalRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedAllObsReported = true;
        string expectedChecklistID = "checklistId";
        string expectedCreationDt = "creationDt";
        double expectedDurationHrs = 0;
        string expectedISOObsDate = "isoObsDate";
        string expectedLastEditedDt = "lastEditedDt";
        Loc expectedLoc = new()
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };
        string expectedLocID = "locId";
        long expectedNumObservers = 0;
        int expectedNumSpecies = 0;
        List<Ob> expectedObs =
        [
            new()
            {
                ObsAux =
                [
                    new()
                    {
                        AuxCode = "auxCode",
                        EntryMethodCode = "entryMethodCode",
                        FieldName = "fieldName",
                        ObsID = "obsId",
                        SpeciesCode = "speciesCode",
                        SubID = "subId",
                        Value = "value",
                    },
                ],
                ObsDt = "obsDt",
                ObsID = "obsId",
                SpeciesCode = "speciesCode",
            },
        ];
        string expectedObsDt = "obsDt";
        string expectedObsTime = "obsTime";
        bool expectedObsTimeValid = true;
        string expectedProjID = "projId";
        string expectedProtocolID = "protocolId";
        string expectedSubID = "subId";
        string expectedSubmissionMethodCode = "submissionMethodCode";
        string expectedSubnational1Code = "subnational1Code";
        string expectedUserDisplayName = "userDisplayName";

        Assert.Equal(expectedAllObsReported, deserialized.AllObsReported);
        Assert.Equal(expectedChecklistID, deserialized.ChecklistID);
        Assert.Equal(expectedCreationDt, deserialized.CreationDt);
        Assert.Equal(expectedDurationHrs, deserialized.DurationHrs);
        Assert.Equal(expectedISOObsDate, deserialized.ISOObsDate);
        Assert.Equal(expectedLastEditedDt, deserialized.LastEditedDt);
        Assert.Equal(expectedLoc, deserialized.Loc);
        Assert.Equal(expectedLocID, deserialized.LocID);
        Assert.Equal(expectedNumObservers, deserialized.NumObservers);
        Assert.Equal(expectedNumSpecies, deserialized.NumSpecies);
        Assert.Equal(expectedObs.Count, deserialized.Obs.Count);
        for (int i = 0; i < expectedObs.Count; i++)
        {
            Assert.Equal(expectedObs[i], deserialized.Obs[i]);
        }
        Assert.Equal(expectedObsDt, deserialized.ObsDt);
        Assert.Equal(expectedObsTime, deserialized.ObsTime);
        Assert.Equal(expectedObsTimeValid, deserialized.ObsTimeValid);
        Assert.Equal(expectedProjID, deserialized.ProjID);
        Assert.Equal(expectedProtocolID, deserialized.ProtocolID);
        Assert.Equal(expectedSubID, deserialized.SubID);
        Assert.Equal(expectedSubmissionMethodCode, deserialized.SubmissionMethodCode);
        Assert.Equal(expectedSubnational1Code, deserialized.Subnational1Code);
        Assert.Equal(expectedUserDisplayName, deserialized.UserDisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            AllObsReported = true,
            ChecklistID = "checklistId",
            CreationDt = "creationDt",
            DurationHrs = 0,
            ISOObsDate = "isoObsDate",
            LastEditedDt = "lastEditedDt",
            Loc = new()
            {
                CountryCode = "countryCode",
                CountryName = "countryName",
                HierarchicalName = "hierarchicalName",
                IsHotspot = true,
                Lat = 0,
                Latitude = 0,
                Lng = 0,
                LocID = "locId",
                LocName = "locName",
                Longitude = 0,
                Name = "name",
                Subnational1Code = "subnational1Code",
                Subnational1Name = "subnational1Name",
            },
            LocID = "locId",
            NumObservers = 0,
            NumSpecies = 0,
            Obs =
            [
                new()
                {
                    ObsAux =
                    [
                        new()
                        {
                            AuxCode = "auxCode",
                            EntryMethodCode = "entryMethodCode",
                            FieldName = "fieldName",
                            ObsID = "obsId",
                            SpeciesCode = "speciesCode",
                            SubID = "subId",
                            Value = "value",
                        },
                    ],
                    ObsDt = "obsDt",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                },
            ],
            ObsDt = "obsDt",
            ObsTime = "obsTime",
            ObsTimeValid = true,
            ProjID = "projId",
            ProtocolID = "protocolId",
            SubID = "subId",
            SubmissionMethodCode = "submissionMethodCode",
            Subnational1Code = "subnational1Code",
            UserDisplayName = "userDisplayName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HistoricalRetrieveResponse { };

        Assert.Null(model.AllObsReported);
        Assert.False(model.RawData.ContainsKey("allObsReported"));
        Assert.Null(model.ChecklistID);
        Assert.False(model.RawData.ContainsKey("checklistId"));
        Assert.Null(model.CreationDt);
        Assert.False(model.RawData.ContainsKey("creationDt"));
        Assert.Null(model.DurationHrs);
        Assert.False(model.RawData.ContainsKey("durationHrs"));
        Assert.Null(model.ISOObsDate);
        Assert.False(model.RawData.ContainsKey("isoObsDate"));
        Assert.Null(model.LastEditedDt);
        Assert.False(model.RawData.ContainsKey("lastEditedDt"));
        Assert.Null(model.Loc);
        Assert.False(model.RawData.ContainsKey("loc"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.NumObservers);
        Assert.False(model.RawData.ContainsKey("numObservers"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
        Assert.Null(model.Obs);
        Assert.False(model.RawData.ContainsKey("obs"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsTime);
        Assert.False(model.RawData.ContainsKey("obsTime"));
        Assert.Null(model.ObsTimeValid);
        Assert.False(model.RawData.ContainsKey("obsTimeValid"));
        Assert.Null(model.ProjID);
        Assert.False(model.RawData.ContainsKey("projId"));
        Assert.Null(model.ProtocolID);
        Assert.False(model.RawData.ContainsKey("protocolId"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
        Assert.Null(model.SubmissionMethodCode);
        Assert.False(model.RawData.ContainsKey("submissionMethodCode"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.UserDisplayName);
        Assert.False(model.RawData.ContainsKey("userDisplayName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HistoricalRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            AllObsReported = null,
            ChecklistID = null,
            CreationDt = null,
            DurationHrs = null,
            ISOObsDate = null,
            LastEditedDt = null,
            Loc = null,
            LocID = null,
            NumObservers = null,
            NumSpecies = null,
            Obs = null,
            ObsDt = null,
            ObsTime = null,
            ObsTimeValid = null,
            ProjID = null,
            ProtocolID = null,
            SubID = null,
            SubmissionMethodCode = null,
            Subnational1Code = null,
            UserDisplayName = null,
        };

        Assert.Null(model.AllObsReported);
        Assert.False(model.RawData.ContainsKey("allObsReported"));
        Assert.Null(model.ChecklistID);
        Assert.False(model.RawData.ContainsKey("checklistId"));
        Assert.Null(model.CreationDt);
        Assert.False(model.RawData.ContainsKey("creationDt"));
        Assert.Null(model.DurationHrs);
        Assert.False(model.RawData.ContainsKey("durationHrs"));
        Assert.Null(model.ISOObsDate);
        Assert.False(model.RawData.ContainsKey("isoObsDate"));
        Assert.Null(model.LastEditedDt);
        Assert.False(model.RawData.ContainsKey("lastEditedDt"));
        Assert.Null(model.Loc);
        Assert.False(model.RawData.ContainsKey("loc"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.NumObservers);
        Assert.False(model.RawData.ContainsKey("numObservers"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
        Assert.Null(model.Obs);
        Assert.False(model.RawData.ContainsKey("obs"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsTime);
        Assert.False(model.RawData.ContainsKey("obsTime"));
        Assert.Null(model.ObsTimeValid);
        Assert.False(model.RawData.ContainsKey("obsTimeValid"));
        Assert.Null(model.ProjID);
        Assert.False(model.RawData.ContainsKey("projId"));
        Assert.Null(model.ProtocolID);
        Assert.False(model.RawData.ContainsKey("protocolId"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
        Assert.Null(model.SubmissionMethodCode);
        Assert.False(model.RawData.ContainsKey("submissionMethodCode"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.UserDisplayName);
        Assert.False(model.RawData.ContainsKey("userDisplayName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HistoricalRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            AllObsReported = null,
            ChecklistID = null,
            CreationDt = null,
            DurationHrs = null,
            ISOObsDate = null,
            LastEditedDt = null,
            Loc = null,
            LocID = null,
            NumObservers = null,
            NumSpecies = null,
            Obs = null,
            ObsDt = null,
            ObsTime = null,
            ObsTimeValid = null,
            ProjID = null,
            ProtocolID = null,
            SubID = null,
            SubmissionMethodCode = null,
            Subnational1Code = null,
            UserDisplayName = null,
        };

        model.Validate();
    }
}

public class LocTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Loc
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };

        string expectedCountryCode = "countryCode";
        string expectedCountryName = "countryName";
        string expectedHierarchicalName = "hierarchicalName";
        bool expectedIsHotspot = true;
        double expectedLat = 0;
        double expectedLatitude = 0;
        double expectedLng = 0;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        double expectedLongitude = 0;
        string expectedName = "name";
        string expectedSubnational1Code = "subnational1Code";
        string expectedSubnational1Name = "subnational1Name";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryName, model.CountryName);
        Assert.Equal(expectedHierarchicalName, model.HierarchicalName);
        Assert.Equal(expectedIsHotspot, model.IsHotspot);
        Assert.Equal(expectedLat, model.Lat);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLng, model.Lng);
        Assert.Equal(expectedLocID, model.LocID);
        Assert.Equal(expectedLocName, model.LocName);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSubnational1Code, model.Subnational1Code);
        Assert.Equal(expectedSubnational1Name, model.Subnational1Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Loc
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Loc>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Loc
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Loc>(json);
        Assert.NotNull(deserialized);

        string expectedCountryCode = "countryCode";
        string expectedCountryName = "countryName";
        string expectedHierarchicalName = "hierarchicalName";
        bool expectedIsHotspot = true;
        double expectedLat = 0;
        double expectedLatitude = 0;
        double expectedLng = 0;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        double expectedLongitude = 0;
        string expectedName = "name";
        string expectedSubnational1Code = "subnational1Code";
        string expectedSubnational1Name = "subnational1Name";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryName, deserialized.CountryName);
        Assert.Equal(expectedHierarchicalName, deserialized.HierarchicalName);
        Assert.Equal(expectedIsHotspot, deserialized.IsHotspot);
        Assert.Equal(expectedLat, deserialized.Lat);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLng, deserialized.Lng);
        Assert.Equal(expectedLocID, deserialized.LocID);
        Assert.Equal(expectedLocName, deserialized.LocName);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSubnational1Code, deserialized.Subnational1Code);
        Assert.Equal(expectedSubnational1Name, deserialized.Subnational1Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Loc
        {
            CountryCode = "countryCode",
            CountryName = "countryName",
            HierarchicalName = "hierarchicalName",
            IsHotspot = true,
            Lat = 0,
            Latitude = 0,
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            Longitude = 0,
            Name = "name",
            Subnational1Code = "subnational1Code",
            Subnational1Name = "subnational1Name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Loc { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("countryName"));
        Assert.Null(model.HierarchicalName);
        Assert.False(model.RawData.ContainsKey("hierarchicalName"));
        Assert.Null(model.IsHotspot);
        Assert.False(model.RawData.ContainsKey("isHotspot"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.Subnational1Name);
        Assert.False(model.RawData.ContainsKey("subnational1Name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Loc { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Loc
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            HierarchicalName = null,
            IsHotspot = null,
            Lat = null,
            Latitude = null,
            Lng = null,
            LocID = null,
            LocName = null,
            Longitude = null,
            Name = null,
            Subnational1Code = null,
            Subnational1Name = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("countryName"));
        Assert.Null(model.HierarchicalName);
        Assert.False(model.RawData.ContainsKey("hierarchicalName"));
        Assert.Null(model.IsHotspot);
        Assert.False(model.RawData.ContainsKey("isHotspot"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.Subnational1Name);
        Assert.False(model.RawData.ContainsKey("subnational1Name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Loc
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            HierarchicalName = null,
            IsHotspot = null,
            Lat = null,
            Latitude = null,
            Lng = null,
            LocID = null,
            LocName = null,
            Longitude = null,
            Name = null,
            Subnational1Code = null,
            Subnational1Name = null,
        };

        model.Validate();
    }
}

public class ObTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ob
        {
            ObsAux =
            [
                new()
                {
                    AuxCode = "auxCode",
                    EntryMethodCode = "entryMethodCode",
                    FieldName = "fieldName",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                    SubID = "subId",
                    Value = "value",
                },
            ],
            ObsDt = "obsDt",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
        };

        List<ObsAux> expectedObsAux =
        [
            new()
            {
                AuxCode = "auxCode",
                EntryMethodCode = "entryMethodCode",
                FieldName = "fieldName",
                ObsID = "obsId",
                SpeciesCode = "speciesCode",
                SubID = "subId",
                Value = "value",
            },
        ];
        string expectedObsDt = "obsDt";
        string expectedObsID = "obsId";
        string expectedSpeciesCode = "speciesCode";

        Assert.Equal(expectedObsAux.Count, model.ObsAux.Count);
        for (int i = 0; i < expectedObsAux.Count; i++)
        {
            Assert.Equal(expectedObsAux[i], model.ObsAux[i]);
        }
        Assert.Equal(expectedObsDt, model.ObsDt);
        Assert.Equal(expectedObsID, model.ObsID);
        Assert.Equal(expectedSpeciesCode, model.SpeciesCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Ob
        {
            ObsAux =
            [
                new()
                {
                    AuxCode = "auxCode",
                    EntryMethodCode = "entryMethodCode",
                    FieldName = "fieldName",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                    SubID = "subId",
                    Value = "value",
                },
            ],
            ObsDt = "obsDt",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ob>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ob
        {
            ObsAux =
            [
                new()
                {
                    AuxCode = "auxCode",
                    EntryMethodCode = "entryMethodCode",
                    FieldName = "fieldName",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                    SubID = "subId",
                    Value = "value",
                },
            ],
            ObsDt = "obsDt",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ob>(json);
        Assert.NotNull(deserialized);

        List<ObsAux> expectedObsAux =
        [
            new()
            {
                AuxCode = "auxCode",
                EntryMethodCode = "entryMethodCode",
                FieldName = "fieldName",
                ObsID = "obsId",
                SpeciesCode = "speciesCode",
                SubID = "subId",
                Value = "value",
            },
        ];
        string expectedObsDt = "obsDt";
        string expectedObsID = "obsId";
        string expectedSpeciesCode = "speciesCode";

        Assert.Equal(expectedObsAux.Count, deserialized.ObsAux.Count);
        for (int i = 0; i < expectedObsAux.Count; i++)
        {
            Assert.Equal(expectedObsAux[i], deserialized.ObsAux[i]);
        }
        Assert.Equal(expectedObsDt, deserialized.ObsDt);
        Assert.Equal(expectedObsID, deserialized.ObsID);
        Assert.Equal(expectedSpeciesCode, deserialized.SpeciesCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Ob
        {
            ObsAux =
            [
                new()
                {
                    AuxCode = "auxCode",
                    EntryMethodCode = "entryMethodCode",
                    FieldName = "fieldName",
                    ObsID = "obsId",
                    SpeciesCode = "speciesCode",
                    SubID = "subId",
                    Value = "value",
                },
            ],
            ObsDt = "obsDt",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ob { };

        Assert.Null(model.ObsAux);
        Assert.False(model.RawData.ContainsKey("obsAux"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsID);
        Assert.False(model.RawData.ContainsKey("obsId"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Ob { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Ob
        {
            // Null should be interpreted as omitted for these properties
            ObsAux = null,
            ObsDt = null,
            ObsID = null,
            SpeciesCode = null,
        };

        Assert.Null(model.ObsAux);
        Assert.False(model.RawData.ContainsKey("obsAux"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsID);
        Assert.False(model.RawData.ContainsKey("obsId"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Ob
        {
            // Null should be interpreted as omitted for these properties
            ObsAux = null,
            ObsDt = null,
            ObsID = null,
            SpeciesCode = null,
        };

        model.Validate();
    }
}

public class ObsAuxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObsAux
        {
            AuxCode = "auxCode",
            EntryMethodCode = "entryMethodCode",
            FieldName = "fieldName",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
            SubID = "subId",
            Value = "value",
        };

        string expectedAuxCode = "auxCode";
        string expectedEntryMethodCode = "entryMethodCode";
        string expectedFieldName = "fieldName";
        string expectedObsID = "obsId";
        string expectedSpeciesCode = "speciesCode";
        string expectedSubID = "subId";
        string expectedValue = "value";

        Assert.Equal(expectedAuxCode, model.AuxCode);
        Assert.Equal(expectedEntryMethodCode, model.EntryMethodCode);
        Assert.Equal(expectedFieldName, model.FieldName);
        Assert.Equal(expectedObsID, model.ObsID);
        Assert.Equal(expectedSpeciesCode, model.SpeciesCode);
        Assert.Equal(expectedSubID, model.SubID);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObsAux
        {
            AuxCode = "auxCode",
            EntryMethodCode = "entryMethodCode",
            FieldName = "fieldName",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
            SubID = "subId",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ObsAux>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObsAux
        {
            AuxCode = "auxCode",
            EntryMethodCode = "entryMethodCode",
            FieldName = "fieldName",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
            SubID = "subId",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ObsAux>(json);
        Assert.NotNull(deserialized);

        string expectedAuxCode = "auxCode";
        string expectedEntryMethodCode = "entryMethodCode";
        string expectedFieldName = "fieldName";
        string expectedObsID = "obsId";
        string expectedSpeciesCode = "speciesCode";
        string expectedSubID = "subId";
        string expectedValue = "value";

        Assert.Equal(expectedAuxCode, deserialized.AuxCode);
        Assert.Equal(expectedEntryMethodCode, deserialized.EntryMethodCode);
        Assert.Equal(expectedFieldName, deserialized.FieldName);
        Assert.Equal(expectedObsID, deserialized.ObsID);
        Assert.Equal(expectedSpeciesCode, deserialized.SpeciesCode);
        Assert.Equal(expectedSubID, deserialized.SubID);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObsAux
        {
            AuxCode = "auxCode",
            EntryMethodCode = "entryMethodCode",
            FieldName = "fieldName",
            ObsID = "obsId",
            SpeciesCode = "speciesCode",
            SubID = "subId",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObsAux { };

        Assert.Null(model.AuxCode);
        Assert.False(model.RawData.ContainsKey("auxCode"));
        Assert.Null(model.EntryMethodCode);
        Assert.False(model.RawData.ContainsKey("entryMethodCode"));
        Assert.Null(model.FieldName);
        Assert.False(model.RawData.ContainsKey("fieldName"));
        Assert.Null(model.ObsID);
        Assert.False(model.RawData.ContainsKey("obsId"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObsAux { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObsAux
        {
            // Null should be interpreted as omitted for these properties
            AuxCode = null,
            EntryMethodCode = null,
            FieldName = null,
            ObsID = null,
            SpeciesCode = null,
            SubID = null,
            Value = null,
        };

        Assert.Null(model.AuxCode);
        Assert.False(model.RawData.ContainsKey("auxCode"));
        Assert.Null(model.EntryMethodCode);
        Assert.False(model.RawData.ContainsKey("entryMethodCode"));
        Assert.Null(model.FieldName);
        Assert.False(model.RawData.ContainsKey("fieldName"));
        Assert.Null(model.ObsID);
        Assert.False(model.RawData.ContainsKey("obsId"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObsAux
        {
            // Null should be interpreted as omitted for these properties
            AuxCode = null,
            EntryMethodCode = null,
            FieldName = null,
            ObsID = null,
            SpeciesCode = null,
            SubID = null,
            Value = null,
        };

        model.Validate();
    }
}
