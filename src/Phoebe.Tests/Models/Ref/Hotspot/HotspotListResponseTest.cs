using System.Text.Json;
using Phoebe.Models.Ref.Hotspot;

namespace Phoebe.Tests.Models.Ref.Hotspot;

public class HotspotListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HotspotListResponse
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HotspotListResponse
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HotspotListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HotspotListResponse
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HotspotListResponse>(element);
        Assert.NotNull(deserialized);

        string expectedCountryCode = "countryCode";
        double expectedLat = 0;
        string expectedLatestObsDt = "latestObsDt";
        double expectedLng = 0;
        string expectedLocID = "locId";
        string expectedLocName = "locName";
        int expectedNumSpeciesAllTime = 0;
        string expectedSubnational1Code = "subnational1Code";
        string expectedSubnational2Code = "subnational2Code";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedLat, deserialized.Lat);
        Assert.Equal(expectedLatestObsDt, deserialized.LatestObsDt);
        Assert.Equal(expectedLng, deserialized.Lng);
        Assert.Equal(expectedLocID, deserialized.LocID);
        Assert.Equal(expectedLocName, deserialized.LocName);
        Assert.Equal(expectedNumSpeciesAllTime, deserialized.NumSpeciesAllTime);
        Assert.Equal(expectedSubnational1Code, deserialized.Subnational1Code);
        Assert.Equal(expectedSubnational2Code, deserialized.Subnational2Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HotspotListResponse
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HotspotListResponse { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.LatestObsDt);
        Assert.False(model.RawData.ContainsKey("latestObsDt"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.NumSpeciesAllTime);
        Assert.False(model.RawData.ContainsKey("numSpeciesAllTime"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.Subnational2Code);
        Assert.False(model.RawData.ContainsKey("subnational2Code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HotspotListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HotspotListResponse
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Lat = null,
            LatestObsDt = null,
            Lng = null,
            LocID = null,
            LocName = null,
            NumSpeciesAllTime = null,
            Subnational1Code = null,
            Subnational2Code = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.LatestObsDt);
        Assert.False(model.RawData.ContainsKey("latestObsDt"));
        Assert.Null(model.Lng);
        Assert.False(model.RawData.ContainsKey("lng"));
        Assert.Null(model.LocID);
        Assert.False(model.RawData.ContainsKey("locId"));
        Assert.Null(model.LocName);
        Assert.False(model.RawData.ContainsKey("locName"));
        Assert.Null(model.NumSpeciesAllTime);
        Assert.False(model.RawData.ContainsKey("numSpeciesAllTime"));
        Assert.Null(model.Subnational1Code);
        Assert.False(model.RawData.ContainsKey("subnational1Code"));
        Assert.Null(model.Subnational2Code);
        Assert.False(model.RawData.ContainsKey("subnational2Code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HotspotListResponse
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Lat = null,
            LatestObsDt = null,
            Lng = null,
            LocID = null,
            LocName = null,
            NumSpeciesAllTime = null,
            Subnational1Code = null,
            Subnational2Code = null,
        };

        model.Validate();
    }
}
