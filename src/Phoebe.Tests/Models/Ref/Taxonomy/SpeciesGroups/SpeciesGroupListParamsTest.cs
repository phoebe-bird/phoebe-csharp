using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Tests.Models.Ref.Taxonomy.SpeciesGroups;

public class SpeciesGroupListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpeciesGroupListParams
        {
            SpeciesGrouping = SpeciesGrouping.Merlin,
            GroupNameLocale = "groupNameLocale",
        };

        ApiEnum<string, SpeciesGrouping> expectedSpeciesGrouping = SpeciesGrouping.Merlin;
        string expectedGroupNameLocale = "groupNameLocale";

        Assert.Equal(expectedSpeciesGrouping, parameters.SpeciesGrouping);
        Assert.Equal(expectedGroupNameLocale, parameters.GroupNameLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpeciesGroupListParams { SpeciesGrouping = SpeciesGrouping.Merlin };

        Assert.Null(parameters.GroupNameLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("groupNameLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpeciesGroupListParams
        {
            SpeciesGrouping = SpeciesGrouping.Merlin,

            // Null should be interpreted as omitted for these properties
            GroupNameLocale = null,
        };

        Assert.Null(parameters.GroupNameLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("groupNameLocale"));
    }

    [Fact]
    public void Url_Works()
    {
        SpeciesGroupListParams parameters = new()
        {
            SpeciesGrouping = SpeciesGrouping.Merlin,
            GroupNameLocale = "groupNameLocale",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.ebird.org/v2/ref/sppgroup/merlin?groupNameLocale=groupNameLocale"),
            url
        );
    }
}

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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
