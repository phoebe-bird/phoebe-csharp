using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Product.Lists.Historical;

namespace Phoebe.Tests.Models.Product.Lists.Historical;

public class HistoricalRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HistoricalRetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            MaxResults = 1,
            SortKey = SortKey.ObsDt,
        };

        string expectedRegionCode = "regionCode";
        long expectedY = 0;
        long expectedM = 1;
        long expectedD = 1;
        long expectedMaxResults = 1;
        ApiEnum<string, SortKey> expectedSortKey = SortKey.ObsDt;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedY, parameters.Y);
        Assert.Equal(expectedM, parameters.M);
        Assert.Equal(expectedD, parameters.D);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.Equal(expectedSortKey, parameters.SortKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HistoricalRetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
        };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SortKey);
        Assert.False(parameters.RawQueryData.ContainsKey("sortKey"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HistoricalRetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,

            // Null should be interpreted as omitted for these properties
            MaxResults = null,
            SortKey = null,
        };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SortKey);
        Assert.False(parameters.RawQueryData.ContainsKey("sortKey"));
    }

    [Fact]
    public void Url_Works()
    {
        HistoricalRetrieveParams parameters = new()
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
            MaxResults = 1,
            SortKey = SortKey.ObsDt,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/product/lists/regionCode/0/1/1?maxResults=1&sortKey=obs_dt"
            ),
            url
        );
    }
}

public class SortKeyTest : TestBase
{
    [Theory]
    [InlineData(SortKey.ObsDt)]
    [InlineData(SortKey.CreationDt)]
    public void Validation_Works(SortKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortKey> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortKey.ObsDt)]
    [InlineData(SortKey.CreationDt)]
    public void SerializationRoundtrip_Works(SortKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortKey> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
