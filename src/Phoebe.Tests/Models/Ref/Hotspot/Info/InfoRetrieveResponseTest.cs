using Phoebe.Models.Ref.Hotspot.Info;

namespace Phoebe.Tests.Models.Ref.Hotspot.Info;

public class InfoRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InfoRetrieveResponse
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
