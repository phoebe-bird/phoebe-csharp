using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Tests.Models.Data.Observations.Recent.Historic;

public class CatTest : TestBase
{
    [Theory]
    [InlineData(Cat.Species)]
    [InlineData(Cat.Slash)]
    [InlineData(Cat.Issf)]
    [InlineData(Cat.Spuh)]
    [InlineData(Cat.Hybrid)]
    [InlineData(Cat.Domestic)]
    [InlineData(Cat.Form)]
    [InlineData(Cat.Intergrade)]
    public void Validation_Works(Cat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cat.Species)]
    [InlineData(Cat.Slash)]
    [InlineData(Cat.Issf)]
    [InlineData(Cat.Spuh)]
    [InlineData(Cat.Hybrid)]
    [InlineData(Cat.Domestic)]
    [InlineData(Cat.Form)]
    [InlineData(Cat.Intergrade)]
    public void SerializationRoundtrip_Works(Cat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DetailTest : TestBase
{
    [Theory]
    [InlineData(Detail.Simple)]
    [InlineData(Detail.Full)]
    public void Validation_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Detail.Simple)]
    [InlineData(Detail.Full)]
    public void SerializationRoundtrip_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RankTest : TestBase
{
    [Theory]
    [InlineData(Rank.Mrec)]
    [InlineData(Rank.Create)]
    public void Validation_Works(Rank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Rank> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Rank>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Rank.Mrec)]
    [InlineData(Rank.Create)]
    public void SerializationRoundtrip_Works(Rank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Rank> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Rank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Rank>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Rank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
