using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Tests.Models.Product.Lists.Historical;

public class SortKeyTest : TestBase
{
    [Theory]
    [InlineData(SortKey.ObsDt)]
    [InlineData(SortKey.CreationDt)]
    public void Validation_Works(SortKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortKey> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortKey.ObsDt)]
    [InlineData(SortKey.CreationDt)]
    public void SerializationRoundtrip_Works(SortKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortKey> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
