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
}
