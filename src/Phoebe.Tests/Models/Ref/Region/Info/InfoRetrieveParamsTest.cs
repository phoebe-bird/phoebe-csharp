using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Tests.Models.Ref.Region.Info;

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
