using System;
using System.Collections.Generic;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Data.Observations.Recent.Notable;

namespace Phoebe.Tests.Models.Data.Observations.Recent.Notable;

public class NotableListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotableListParams
        {
            RegionCode = "regionCode",
            Back = 1,
            Detail = Detail.Simple,
            Hotspot = true,
            MaxResults = 1,
            R = ["string"],
            SppLocale = "sppLocale",
        };

        string expectedRegionCode = "regionCode";
        long expectedBack = 1;
        ApiEnum<string, Detail> expectedDetail = Detail.Simple;
        bool expectedHotspot = true;
        long expectedMaxResults = 1;
        List<string> expectedR = ["string"];
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedDetail, parameters.Detail);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.NotNull(parameters.R);
        Assert.Equal(expectedR.Count, parameters.R.Count);
        for (int i = 0; i < expectedR.Count; i++)
        {
            Assert.Equal(expectedR[i], parameters.R[i]);
        }
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotableListParams { RegionCode = "regionCode" };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotableListParams
        {
            RegionCode = "regionCode",

            // Null should be interpreted as omitted for these properties
            Back = null,
            Detail = null,
            Hotspot = null,
            MaxResults = null,
            R = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Detail);
        Assert.False(parameters.RawQueryData.ContainsKey("detail"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void Url_Works()
    {
        NotableListParams parameters = new()
        {
            RegionCode = "regionCode",
            Back = 1,
            Detail = Detail.Simple,
            Hotspot = true,
            MaxResults = 1,
            R = ["string"],
            SppLocale = "sppLocale",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/data/obs/regionCode/recent/notable?back=1&detail=simple&hotspot=true&maxResults=1&r=string&sppLocale=sppLocale"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotableListParams
        {
            RegionCode = "regionCode",
            Back = 1,
            Detail = Detail.Simple,
            Hotspot = true,
            MaxResults = 1,
            R = ["string"],
            SppLocale = "sppLocale",
        };

        NotableListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
