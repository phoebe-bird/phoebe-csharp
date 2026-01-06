using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Tests.Models.Ref.Region.Info;

public class InfoRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InfoRetrieveParams
        {
            RegionCode = "regionCode",
            Delim = "delim",
            RegionNameFormat = RegionNameFormat.Detailed,
        };

        string expectedRegionCode = "regionCode";
        string expectedDelim = "delim";
        ApiEnum<string, RegionNameFormat> expectedRegionNameFormat = RegionNameFormat.Detailed;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedDelim, parameters.Delim);
        Assert.Equal(expectedRegionNameFormat, parameters.RegionNameFormat);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InfoRetrieveParams { RegionCode = "regionCode" };

        Assert.Null(parameters.Delim);
        Assert.False(parameters.RawQueryData.ContainsKey("delim"));
        Assert.Null(parameters.RegionNameFormat);
        Assert.False(parameters.RawQueryData.ContainsKey("regionNameFormat"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InfoRetrieveParams
        {
            RegionCode = "regionCode",

            // Null should be interpreted as omitted for these properties
            Delim = null,
            RegionNameFormat = null,
        };

        Assert.Null(parameters.Delim);
        Assert.False(parameters.RawQueryData.ContainsKey("delim"));
        Assert.Null(parameters.RegionNameFormat);
        Assert.False(parameters.RawQueryData.ContainsKey("regionNameFormat"));
    }

    [Fact]
    public void Url_Works()
    {
        InfoRetrieveParams parameters = new()
        {
            RegionCode = "regionCode",
            Delim = "delim",
            RegionNameFormat = RegionNameFormat.Detailed,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/ref/region/info/regionCode?delim=delim&regionNameFormat=detailed"
            ),
            url
        );
    }
}

public class RegionNameFormatTest : TestBase
{
    [Theory]
    [InlineData(RegionNameFormat.Detailed)]
    [InlineData(RegionNameFormat.Detailednoqual)]
    [InlineData(RegionNameFormat.Full)]
    [InlineData(RegionNameFormat.Namequal)]
    [InlineData(RegionNameFormat.Nameonly)]
    [InlineData(RegionNameFormat.Revdetailed)]
    public void Validation_Works(RegionNameFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionNameFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionNameFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RegionNameFormat.Detailed)]
    [InlineData(RegionNameFormat.Detailednoqual)]
    [InlineData(RegionNameFormat.Full)]
    [InlineData(RegionNameFormat.Namequal)]
    [InlineData(RegionNameFormat.Nameonly)]
    [InlineData(RegionNameFormat.Revdetailed)]
    public void SerializationRoundtrip_Works(RegionNameFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionNameFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionNameFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionNameFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionNameFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
