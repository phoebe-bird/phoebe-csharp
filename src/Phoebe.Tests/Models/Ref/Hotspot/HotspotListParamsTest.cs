using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Hotspot;

namespace Phoebe.Tests.Models.Ref.Hotspot;

public class HotspotListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HotspotListParams
        {
            RegionCode = "regionCode",
            Back = 1,
            Fmt = Fmt.Csv,
        };

        string expectedRegionCode = "regionCode";
        long expectedBack = 1;
        ApiEnum<string, Fmt> expectedFmt = Fmt.Csv;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedFmt, parameters.Fmt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HotspotListParams { RegionCode = "regionCode" };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HotspotListParams
        {
            RegionCode = "regionCode",

            // Null should be interpreted as omitted for these properties
            Back = null,
            Fmt = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
    }

    [Fact]
    public void Url_Works()
    {
        HotspotListParams parameters = new()
        {
            RegionCode = "regionCode",
            Back = 1,
            Fmt = Fmt.Csv,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.ebird.org/v2/ref/hotspot/regionCode?back=1&fmt=csv"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HotspotListParams
        {
            RegionCode = "regionCode",
            Back = 1,
            Fmt = Fmt.Csv,
        };

        HotspotListParams copied = new(parameters);

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
