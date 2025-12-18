using System.Text.Json;
using Phoebe.Models.Product.Stats;

namespace Phoebe.Tests.Models.Product.Stats;

public class StatRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StatRetrieveResponse
        {
            NumChecklists = 0,
            NumContributors = 0,
            NumSpecies = 0,
        };

        int expectedNumChecklists = 0;
        int expectedNumContributors = 0;
        int expectedNumSpecies = 0;

        Assert.Equal(expectedNumChecklists, model.NumChecklists);
        Assert.Equal(expectedNumContributors, model.NumContributors);
        Assert.Equal(expectedNumSpecies, model.NumSpecies);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StatRetrieveResponse
        {
            NumChecklists = 0,
            NumContributors = 0,
            NumSpecies = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StatRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StatRetrieveResponse
        {
            NumChecklists = 0,
            NumContributors = 0,
            NumSpecies = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StatRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        int expectedNumChecklists = 0;
        int expectedNumContributors = 0;
        int expectedNumSpecies = 0;

        Assert.Equal(expectedNumChecklists, deserialized.NumChecklists);
        Assert.Equal(expectedNumContributors, deserialized.NumContributors);
        Assert.Equal(expectedNumSpecies, deserialized.NumSpecies);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StatRetrieveResponse
        {
            NumChecklists = 0,
            NumContributors = 0,
            NumSpecies = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StatRetrieveResponse { };

        Assert.Null(model.NumChecklists);
        Assert.False(model.RawData.ContainsKey("numChecklists"));
        Assert.Null(model.NumContributors);
        Assert.False(model.RawData.ContainsKey("numContributors"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StatRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StatRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            NumChecklists = null,
            NumContributors = null,
            NumSpecies = null,
        };

        Assert.Null(model.NumChecklists);
        Assert.False(model.RawData.ContainsKey("numChecklists"));
        Assert.Null(model.NumContributors);
        Assert.False(model.RawData.ContainsKey("numContributors"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StatRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            NumChecklists = null,
            NumContributors = null,
            NumSpecies = null,
        };

        model.Validate();
    }
}
