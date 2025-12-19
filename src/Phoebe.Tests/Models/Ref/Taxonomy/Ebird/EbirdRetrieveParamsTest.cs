using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.Ebird;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Ebird;

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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
