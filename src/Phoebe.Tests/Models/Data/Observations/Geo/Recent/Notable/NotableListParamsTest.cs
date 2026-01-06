using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations.Geo.Recent.Notable;

namespace Phoebe.Tests.Models.Data.Observations.Geo.Recent.Notable;

public class NotableListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotableListParams
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Detail = Detail.Simple,
            Dist = 0,
            Hotspot = true,
            MaxResults = 1,
            SppLocale = "sppLocale",
        };

        float expectedLat = -90;
        float expectedLng = -180;
        long expectedBack = 1;
        ApiEnum<string, Detail> expectedDetail = Detail.Simple;
        long expectedDist = 0;
        bool expectedHotspot = true;
        long expectedMaxResults = 1;
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedLat, parameters.Lat);
        Assert.Equal(expectedLng, parameters.Lng);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedDetail, parameters.Detail);
        Assert.Equal(expectedDist, parameters.Dist);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotableListParams { Lat = -90, Lng = -180 };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotableListParams
        {
            Lat = -90,
            Lng = -180,

            // Null should be interpreted as omitted for these properties
            Back = null,
            Detail = null,
            Dist = null,
            Hotspot = null,
            MaxResults = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void Url_Works()
    {
        NotableListParams parameters = new()
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Detail = Detail.Simple,
            Dist = 0,
            Hotspot = true,
            MaxResults = 1,
            SppLocale = "sppLocale",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/data/obs/geo/recent/notable?lat=-90&lng=-180&back=1&detail=simple&dist=0&hotspot=true&maxResults=1&sppLocale=sppLocale"
            ),
            url
        );
    }
}

public class DetailTest : TestBase
{
    [Theory]
    [InlineData(Detail.Simple)]
    [InlineData(Detail.Full)]
    public void Validation_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Detail.Simple)]
    [InlineData(Detail.Full)]
    public void SerializationRoundtrip_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
