using System.Text.Json;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Tests.Models.Ref.Region.Adjacent;

public class AdjacentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AdjacentListResponse { Code = "US-CT", Name = "Connecticut" };

        string expectedCode = "US-CT";
        string expectedName = "Connecticut";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AdjacentListResponse { Code = "US-CT", Name = "Connecticut" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AdjacentListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AdjacentListResponse { Code = "US-CT", Name = "Connecticut" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AdjacentListResponse>(element);
        Assert.NotNull(deserialized);

        string expectedCode = "US-CT";
        string expectedName = "Connecticut";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AdjacentListResponse { Code = "US-CT", Name = "Connecticut" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AdjacentListResponse { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AdjacentListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AdjacentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Name = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AdjacentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Name = null,
        };

        model.Validate();
    }
}
