using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Tests.Models.Ref.Taxonomy.SpeciesGroups;

public class SpeciesGroupingTest : TestBase
{
    [Theory]
    [InlineData(SpeciesGrouping.Merlin)]
    [InlineData(SpeciesGrouping.Ebird)]
    public void Validation_Works(SpeciesGrouping rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeciesGrouping> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeciesGrouping>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpeciesGrouping.Merlin)]
    [InlineData(SpeciesGrouping.Ebird)]
    public void SerializationRoundtrip_Works(SpeciesGrouping rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpeciesGrouping> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpeciesGrouping>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpeciesGrouping>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpeciesGrouping>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
