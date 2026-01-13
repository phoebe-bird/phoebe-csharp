using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations.Geo.Recent;

namespace Phoebe.Tests.Models.Data.Observations.Geo.Recent;

public class RecentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecentListParams
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Cat = Cat.Species,
            Dist = 0,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            Sort = Sort.Date,
            SppLocale = "sppLocale",
        };

        float expectedLat = -90;
        float expectedLng = -180;
        long expectedBack = 1;
        ApiEnum<string, Cat> expectedCat = Cat.Species;
        long expectedDist = 0;
        bool expectedHotspot = true;
        bool expectedIncludeProvisional = true;
        long expectedMaxResults = 1;
        ApiEnum<string, Sort> expectedSort = Sort.Date;
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedLat, parameters.Lat);
        Assert.Equal(expectedLng, parameters.Lng);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedCat, parameters.Cat);
        Assert.Equal(expectedDist, parameters.Dist);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedIncludeProvisional, parameters.IncludeProvisional);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.Equal(expectedSort, parameters.Sort);
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecentListParams { Lat = -90, Lng = -180 };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecentListParams
        {
            Lat = -90,
            Lng = -180,

            // Null should be interpreted as omitted for these properties
            Back = null,
            Cat = null,
            Dist = null,
            Hotspot = null,
            IncludeProvisional = null,
            MaxResults = null,
            Sort = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void Url_Works()
    {
        RecentListParams parameters = new()
        {
            Lat = -90,
            Lng = -180,
            Back = 1,
            Cat = Cat.Species,
            Dist = 0,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            Sort = Sort.Date,
            SppLocale = "sppLocale",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/data/obs/geo/recent?lat=-90&lng=-180&back=1&cat=species&dist=0&hotspot=true&includeProvisional=true&maxResults=1&sort=date&sppLocale=sppLocale"
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Sort.Date)]
    [InlineData(Sort.Species)]
    public void Validation_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sort.Date)]
    [InlineData(Sort.Species)]
    public void SerializationRoundtrip_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
