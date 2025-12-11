using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Tests.Models.Product.Top100;

public class RankedByTest : TestBase
{
    [Theory]
    [InlineData(RankedBy.Spp)]
    [InlineData(RankedBy.Cl)]
    public void Validation_Works(RankedBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RankedBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RankedBy.Spp)]
    [InlineData(RankedBy.Cl)]
    public void SerializationRoundtrip_Works(RankedBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RankedBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
