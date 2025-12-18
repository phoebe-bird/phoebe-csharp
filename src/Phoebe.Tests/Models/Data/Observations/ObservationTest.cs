using System.Text.Json;
using Phoebe.Models.Data.Observations;

namespace Phoebe.Tests.Models.Data.Observations;

public class ObservationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Observation
        {
            ID = 0,
            ComName = "comName",
            Firstname = "firstname",
            HowMany = 0,
            Lastname = "lastname",
            Lat = 0,
            Lng = 0,
            LocationPrivate = true,
            LocID = "locId",
            LocName = "locName",
            ObsDt = "obsDt",
            ObsReviewed = true,
            ObsValid = true,
            SciName = "sciName",
            SpeciesCode = "speciesCode",
            SubID = "subId",
        };

        long expectedID = 0;
        string expectedComName = "comName";
        string expectedFirstname = "firstname";
        long expectedHowMany = 0;
        string expectedLastname = "lastname";
        float expectedLat = 0;
        float expectedLng = 0;
        bool expectedLocationPrivate = true;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        string expectedObsDt = "obsDt";
        bool expectedObsReviewed = true;
        bool expectedObsValid = true;
        string expectedSciName = "sciName";
        string expectedSpeciesCode = "speciesCode";
        string expectedSubID = "subId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComName, model.ComName);
        Assert.Equal(expectedFirstname, model.Firstname);
        Assert.Equal(expectedHowMany, model.HowMany);
        Assert.Equal(expectedLastname, model.Lastname);
        Assert.Equal(expectedLat, model.Lat);
        Assert.Equal(expectedLng, model.Lng);
        Assert.Equal(expectedLocationPrivate, model.LocationPrivate);
        Assert.Equal(expectedLocID, model.LocID);
        Assert.Equal(expectedLocName, model.LocName);
        Assert.Equal(expectedObsDt, model.ObsDt);
        Assert.Equal(expectedObsReviewed, model.ObsReviewed);
        Assert.Equal(expectedObsValid, model.ObsValid);
        Assert.Equal(expectedSciName, model.SciName);
        Assert.Equal(expectedSpeciesCode, model.SpeciesCode);
        Assert.Equal(expectedSubID, model.SubID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Observation
        {
            ID = 0,
            ComName = "comName",
            Firstname = "firstname",
            HowMany = 0,
            Lastname = "lastname",
            Lat = 0,
            Lng = 0,
            LocationPrivate = true,
            LocID = "locId",
            LocName = "locName",
            ObsDt = "obsDt",
            ObsReviewed = true,
            ObsValid = true,
            SciName = "sciName",
            SpeciesCode = "speciesCode",
            SubID = "subId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Observation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Observation
        {
            ID = 0,
            ComName = "comName",
            Firstname = "firstname",
            HowMany = 0,
            Lastname = "lastname",
            Lat = 0,
            Lng = 0,
            LocationPrivate = true,
            LocID = "locId",
            LocName = "locName",
            ObsDt = "obsDt",
            ObsReviewed = true,
            ObsValid = true,
            SciName = "sciName",
            SpeciesCode = "speciesCode",
            SubID = "subId",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Observation>(element);
        Assert.NotNull(deserialized);

        long expectedID = 0;
        string expectedComName = "comName";
        string expectedFirstname = "firstname";
        long expectedHowMany = 0;
        string expectedLastname = "lastname";
        float expectedLat = 0;
        float expectedLng = 0;
        bool expectedLocationPrivate = true;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        string expectedObsDt = "obsDt";
        bool expectedObsReviewed = true;
        bool expectedObsValid = true;
        string expectedSciName = "sciName";
        string expectedSpeciesCode = "speciesCode";
        string expectedSubID = "subId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComName, deserialized.ComName);
        Assert.Equal(expectedFirstname, deserialized.Firstname);
        Assert.Equal(expectedHowMany, deserialized.HowMany);
        Assert.Equal(expectedLastname, deserialized.Lastname);
        Assert.Equal(expectedLat, deserialized.Lat);
        Assert.Equal(expectedLng, deserialized.Lng);
        Assert.Equal(expectedLocationPrivate, deserialized.LocationPrivate);
        Assert.Equal(expectedLocID, deserialized.LocID);
        Assert.Equal(expectedLocName, deserialized.LocName);
        Assert.Equal(expectedObsDt, deserialized.ObsDt);
        Assert.Equal(expectedObsReviewed, deserialized.ObsReviewed);
        Assert.Equal(expectedObsValid, deserialized.ObsValid);
        Assert.Equal(expectedSciName, deserialized.SciName);
        Assert.Equal(expectedSpeciesCode, deserialized.SpeciesCode);
        Assert.Equal(expectedSubID, deserialized.SubID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Observation
        {
            ID = 0,
            ComName = "comName",
            Firstname = "firstname",
            HowMany = 0,
            Lastname = "lastname",
            Lat = 0,
            Lng = 0,
            LocationPrivate = true,
            LocID = "locId",
            LocName = "locName",
            ObsDt = "obsDt",
            ObsReviewed = true,
            ObsValid = true,
            SciName = "sciName",
            SpeciesCode = "speciesCode",
            SubID = "subId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Observation { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ComName);
        Assert.False(model.RawData.ContainsKey("comName"));
        Assert.Null(model.Firstname);
        Assert.False(model.RawData.ContainsKey("firstname"));
        Assert.Null(model.HowMany);
        Assert.False(model.RawData.ContainsKey("howMany"));
        Assert.Null(model.Lastname);
        Assert.False(model.RawData.ContainsKey("lastname"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocationPrivate);
        Assert.False(model.RawData.ContainsKey("locationPrivate"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsReviewed);
        Assert.False(model.RawData.ContainsKey("obsReviewed"));
        Assert.Null(model.ObsValid);
        Assert.False(model.RawData.ContainsKey("obsValid"));
        Assert.Null(model.SciName);
        Assert.False(model.RawData.ContainsKey("sciName"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Observation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Observation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ComName = null,
            Firstname = null,
            HowMany = null,
            Lastname = null,
            Lat = null,
            Lng = null,
            LocationPrivate = null,
            LocID = null,
            LocName = null,
            ObsDt = null,
            ObsReviewed = null,
            ObsValid = null,
            SciName = null,
            SpeciesCode = null,
            SubID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ComName);
        Assert.False(model.RawData.ContainsKey("comName"));
        Assert.Null(model.Firstname);
        Assert.False(model.RawData.ContainsKey("firstname"));
        Assert.Null(model.HowMany);
        Assert.False(model.RawData.ContainsKey("howMany"));
        Assert.Null(model.Lastname);
        Assert.False(model.RawData.ContainsKey("lastname"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocationPrivate);
        Assert.False(model.RawData.ContainsKey("locationPrivate"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.ObsDt);
        Assert.False(model.RawData.ContainsKey("obsDt"));
        Assert.Null(model.ObsReviewed);
        Assert.False(model.RawData.ContainsKey("obsReviewed"));
        Assert.Null(model.ObsValid);
        Assert.False(model.RawData.ContainsKey("obsValid"));
        Assert.Null(model.SciName);
        Assert.False(model.RawData.ContainsKey("sciName"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.SubID);
        Assert.False(model.RawData.ContainsKey("subId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Observation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ComName = null,
            Firstname = null,
            HowMany = null,
            Lastname = null,
            Lat = null,
            Lng = null,
            LocationPrivate = null,
            LocID = null,
            LocName = null,
            ObsDt = null,
            ObsReviewed = null,
            ObsValid = null,
            SciName = null,
            SpeciesCode = null,
            SubID = null,
        };

        model.Validate();
    }
}
