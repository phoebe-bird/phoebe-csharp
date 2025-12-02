using System.Collections.Generic;
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
}
