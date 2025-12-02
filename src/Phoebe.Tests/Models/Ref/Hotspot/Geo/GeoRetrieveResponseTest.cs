using Phoebe.Models.Ref.Hotspot.Geo;

namespace Phoebe.Tests.Models.Ref.Hotspot.Geo;

public class GeoRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeoRetrieveResponse
        {
            CountryCode = "countryCode",
            Lat = 0,
            LatestObsDt = "latestObsDt",
            Lng = 0,
            LocID = "locId",
            LocName = "locName",
            NumSpeciesAllTime = 0,
            Subnational1Code = "subnational1Code",
            Subnational2Code = "subnational2Code",
        };

        string expectedCountryCode = "countryCode";
        double expectedLat = 0;
        string expectedLatestObsDt = "latestObsDt";
        double expectedLng = 0;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        int expectedNumSpeciesAllTime = 0;
        string expectedSubnational1Code = "subnational1Code";
        string expectedSubnational2Code = "subnational2Code";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedLat, model.Lat);
        Assert.Equal(expectedLatestObsDt, model.LatestObsDt);
        Assert.Equal(expectedLng, model.Lng);
        Assert.Equal(expectedLocID, model.LocID);
        Assert.Equal(expectedLocName, model.LocName);
        Assert.Equal(expectedNumSpeciesAllTime, model.NumSpeciesAllTime);
        Assert.Equal(expectedSubnational1Code, model.Subnational1Code);
        Assert.Equal(expectedSubnational2Code, model.Subnational2Code);
    }
}
