using System.Text.Json;
using Phoebe.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InfoRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InfoRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InfoRetrieveResponse { };

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
        var model = new InfoRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InfoRetrieveResponse
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
        var model = new InfoRetrieveResponse
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
