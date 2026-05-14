using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Hotspot.Geo;

namespace Phoebe.Tests.Models.Ref.Hotspot.Geo;

public class GeoRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GeoRetrieveParams
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Dist = 0,
            Fmt = Fmt.Csv,
        };

        float expectedLat = -90;
        float expectedLng = -180;
        long expectedBack = 1;
        long expectedDist = 0;
        ApiEnum<string, Fmt> expectedFmt = Fmt.Csv;

        Assert.Equal(expectedLat, parameters.Lat);
        Assert.Equal(expectedLng, parameters.Lng);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedDist, parameters.Dist);
        Assert.Equal(expectedFmt, parameters.Fmt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeoRetrieveParams { Lat = -90, Lng = -180 };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GeoRetrieveParams
        {
            Lat = -90,
            Lng = -180,

            // Null should be interpreted as omitted for these properties
            Back = null,
            Dist = null,
            Fmt = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
    }

    [Fact]
    public void Url_Works()
    {
        GeoRetrieveParams parameters = new()
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Dist = 0,
            Fmt = Fmt.Csv,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.ebird.org/v2/ref/hotspot/geo?lat=-90&lng=-180&back=1&dist=0&fmt=csv"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GeoRetrieveParams
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Dist = 0,
            Fmt = Fmt.Csv,
        };

        GeoRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FmtTest : TestBase
{
    [Theory]
    [InlineData(Fmt.Csv)]
    [InlineData(Fmt.Json)]
    public void Validation_Works(Fmt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fmt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Fmt.Csv)]
    [InlineData(Fmt.Json)]
    public void SerializationRoundtrip_Works(Fmt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fmt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
