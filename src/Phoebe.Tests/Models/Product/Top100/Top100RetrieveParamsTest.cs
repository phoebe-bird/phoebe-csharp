using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Tests.Models.Product.Top100;

public class Top100RetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Top100RetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            MaxResults = 1,
            RankedBy = RankedBy.Spp,
        };

        string expectedRegionCode = "regionCode";
        long expectedY = 0;
        long expectedM = 1;
        long expectedD = 1;
        long expectedMaxResults = 1;
        ApiEnum<string, RankedBy> expectedRankedBy = RankedBy.Spp;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedY, parameters.Y);
        Assert.Equal(expectedM, parameters.M);
        Assert.Equal(expectedD, parameters.D);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.Equal(expectedRankedBy, parameters.RankedBy);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Top100RetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
        };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.RankedBy);
        Assert.False(parameters.RawQueryData.ContainsKey("rankedBy"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Top100RetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,

            // Null should be interpreted as omitted for these properties
            MaxResults = null,
            RankedBy = null,
        };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.RankedBy);
        Assert.False(parameters.RawQueryData.ContainsKey("rankedBy"));
    }

    [Fact]
    public void Url_Works()
    {
        Top100RetrieveParams parameters = new()
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            MaxResults = 1,
            RankedBy = RankedBy.Spp,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.ebird.org/v2/product/top100/regionCode/0/1/1?maxResults=1&rankedBy=spp"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Top100RetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            MaxResults = 1,
            RankedBy = RankedBy.Spp,
        };

        Top100RetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RankedByTest : TestBase
{
    [Theory]
    [InlineData(RankedBy.Spp)]
    [InlineData(RankedBy.Cl)]
    public void Validation_Works(RankedBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RankedBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RankedBy.Spp)]
    [InlineData(RankedBy.Cl)]
    public void SerializationRoundtrip_Works(RankedBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RankedBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RankedBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
