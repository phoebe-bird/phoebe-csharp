using System.Text.Json;
using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Tests.Models.Ref.Region.Info;

public class InfoRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InfoRetrieveResponse
        {
            Bounds = new()
            {
                MaxX = -75.764f,
                MaxY = 42.896f,
                MinX = -75.764f,
                MinY = 42.896f,
            },
            Result = "Madison, New York, United States",
        };

        Bounds expectedBounds = new()
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };
        string expectedResult = "Madison, New York, United States";

        Assert.Equal(expectedBounds, model.Bounds);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InfoRetrieveResponse
        {
            Bounds = new()
            {
                MaxX = -75.764f,
                MaxY = 42.896f,
                MinX = -75.764f,
                MinY = 42.896f,
            },
            Result = "Madison, New York, United States",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InfoRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InfoRetrieveResponse
        {
            Bounds = new()
            {
                MaxX = -75.764f,
                MaxY = 42.896f,
                MinX = -75.764f,
                MinY = 42.896f,
            },
            Result = "Madison, New York, United States",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InfoRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        Bounds expectedBounds = new()
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };
        string expectedResult = "Madison, New York, United States";

        Assert.Equal(expectedBounds, deserialized.Bounds);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InfoRetrieveResponse
        {
            Bounds = new()
            {
                MaxX = -75.764f,
                MaxY = 42.896f,
                MinX = -75.764f,
                MinY = 42.896f,
            },
            Result = "Madison, New York, United States",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InfoRetrieveResponse { };

        Assert.Null(model.Bounds);
        Assert.False(model.RawData.ContainsKey("bounds"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InfoRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InfoRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Bounds = null,
            Result = null,
        };

        Assert.Null(model.Bounds);
        Assert.False(model.RawData.ContainsKey("bounds"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InfoRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Bounds = null,
            Result = null,
        };

        model.Validate();
    }
}

public class BoundsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Bounds
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };

        float expectedMaxX = -75.764f;
        float expectedMaxY = 42.896f;
        float expectedMinX = -75.764f;
        float expectedMinY = 42.896f;

        Assert.Equal(expectedMaxX, model.MaxX);
        Assert.Equal(expectedMaxY, model.MaxY);
        Assert.Equal(expectedMinX, model.MinX);
        Assert.Equal(expectedMinY, model.MinY);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Bounds
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Bounds>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Bounds
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Bounds>(element);
        Assert.NotNull(deserialized);

        float expectedMaxX = -75.764f;
        float expectedMaxY = 42.896f;
        float expectedMinX = -75.764f;
        float expectedMinY = 42.896f;

        Assert.Equal(expectedMaxX, deserialized.MaxX);
        Assert.Equal(expectedMaxY, deserialized.MaxY);
        Assert.Equal(expectedMinX, deserialized.MinX);
        Assert.Equal(expectedMinY, deserialized.MinY);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Bounds
        {
            MaxX = -75.764f,
            MaxY = 42.896f,
            MinX = -75.764f,
            MinY = 42.896f,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Bounds { };

        Assert.Null(model.MaxX);
        Assert.False(model.RawData.ContainsKey("maxX"));
        Assert.Null(model.MaxY);
        Assert.False(model.RawData.ContainsKey("maxY"));
        Assert.Null(model.MinX);
        Assert.False(model.RawData.ContainsKey("minX"));
        Assert.Null(model.MinY);
        Assert.False(model.RawData.ContainsKey("minY"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Bounds { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Bounds
        {
            // Null should be interpreted as omitted for these properties
            MaxX = null,
            MaxY = null,
            MinX = null,
            MinY = null,
        };

        Assert.Null(model.MaxX);
        Assert.False(model.RawData.ContainsKey("maxX"));
        Assert.Null(model.MaxY);
        Assert.False(model.RawData.ContainsKey("maxY"));
        Assert.Null(model.MinX);
        Assert.False(model.RawData.ContainsKey("minX"));
        Assert.Null(model.MinY);
        Assert.False(model.RawData.ContainsKey("minY"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Bounds
        {
            // Null should be interpreted as omitted for these properties
            MaxX = null,
            MaxY = null,
            MinX = null,
            MinY = null,
        };

        model.Validate();
    }
}
