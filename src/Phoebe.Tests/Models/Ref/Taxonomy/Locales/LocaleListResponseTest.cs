using System.Text.Json;
using Phoebe.Core;
using Phoebe.Models.Ref.Taxonomy.Locales;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Locales;

public class LocaleListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocaleListResponse
        {
            Code = "en",
            LastUpdated = "2023-10-29 12:50",
            Name = "English",
        };

        string expectedCode = "en";
        string expectedLastUpdated = "2023-10-29 12:50";
        string expectedName = "English";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedLastUpdated, model.LastUpdated);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocaleListResponse
        {
            Code = "en",
            LastUpdated = "2023-10-29 12:50",
            Name = "English",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocaleListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocaleListResponse
        {
            Code = "en",
            LastUpdated = "2023-10-29 12:50",
            Name = "English",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocaleListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "en";
        string expectedLastUpdated = "2023-10-29 12:50";
        string expectedName = "English";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedLastUpdated, deserialized.LastUpdated);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocaleListResponse
        {
            Code = "en",
            LastUpdated = "2023-10-29 12:50",
            Name = "English",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LocaleListResponse { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.LastUpdated);
        Assert.False(model.RawData.ContainsKey("lastUpdated"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LocaleListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LocaleListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            LastUpdated = null,
            Name = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.LastUpdated);
        Assert.False(model.RawData.ContainsKey("lastUpdated"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LocaleListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            LastUpdated = null,
            Name = null,
        };

        model.Validate();
    }
}
