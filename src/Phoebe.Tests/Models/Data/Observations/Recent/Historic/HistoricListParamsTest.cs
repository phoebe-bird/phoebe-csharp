using System;
using System.Collections.Generic;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations.Recent.Historic;

namespace Phoebe.Tests.Models.Data.Observations.Recent.Historic;

public class HistoricListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HistoricListParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            Cat = Cat.Species,
            Detail = Detail.Simple,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            R = ["string"],
            Rank = Rank.Mrec,
            SppLocale = "sppLocale",
        };

        string expectedRegionCode = "regionCode";
        long expectedY = 0;
        long expectedM = 1;
        long expectedD = 1;
        ApiEnum<string, Cat> expectedCat = Cat.Species;
        ApiEnum<string, Detail> expectedDetail = Detail.Simple;
        bool expectedHotspot = true;
        bool expectedIncludeProvisional = true;
        long expectedMaxResults = 1;
        List<string> expectedR = ["string"];
        ApiEnum<string, Rank> expectedRank = Rank.Mrec;
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedY, parameters.Y);
        Assert.Equal(expectedM, parameters.M);
        Assert.Equal(expectedD, parameters.D);
        Assert.Equal(expectedCat, parameters.Cat);
        Assert.Equal(expectedDetail, parameters.Detail);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedIncludeProvisional, parameters.IncludeProvisional);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.NotNull(parameters.R);
        Assert.Equal(expectedR.Count, parameters.R.Count);
        for (int i = 0; i < expectedR.Count; i++)
        {
            Assert.Equal(expectedR[i], parameters.R[i]);
        }
        Assert.Equal(expectedRank, parameters.Rank);
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HistoricListParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
        };

        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.Rank);
        Assert.False(parameters.RawQueryData.ContainsKey("rank"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HistoricListParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,

            // Null should be interpreted as omitted for these properties
            Cat = null,
            Detail = null,
            Hotspot = null,
            IncludeProvisional = null,
            MaxResults = null,
            R = null,
            Rank = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.Rank);
        Assert.False(parameters.RawQueryData.ContainsKey("rank"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void Url_Works()
    {
        HistoricListParams parameters = new()
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            Cat = Cat.Species,
            Detail = Detail.Simple,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            R = ["string"],
            Rank = Rank.Mrec,
            SppLocale = "sppLocale",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/data/obs/regionCode/historic/0/1/1?cat=species&detail=simple&hotspot=true&includeProvisional=true&maxResults=1&r=string&rank=mrec&sppLocale=sppLocale"
            ),
            url
        );
    }
}

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
