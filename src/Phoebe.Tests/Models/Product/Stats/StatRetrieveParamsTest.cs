using System;
using Phoebe.Models.Product.Stats;

namespace Phoebe.Tests.Models.Product.Stats;

public class StatRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StatRetrieveParams
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
        };

        string expectedRegionCode = "regionCode";
        long expectedY = 0;
        long expectedM = 1;
        long expectedD = 1;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedY, parameters.Y);
        Assert.Equal(expectedM, parameters.M);
        Assert.Equal(expectedD, parameters.D);
    }

    [Fact]
    public void Url_Works()
    {
        StatRetrieveParams parameters = new()
        {
            RegionCode = "regionCode",
            Y = 0,
            M = 1,
            D = 1,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/product/stats/regionCode/0/1/1"), url);
    }
}
