using System;
using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Tests.Models.Ref.Region.Adjacent;

public class AdjacentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AdjacentListParams { RegionCode = "regionCode" };

        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
    }

    [Fact]
    public void Url_Works()
    {
        AdjacentListParams parameters = new() { RegionCode = "regionCode" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/ref/adjacent/regionCode"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AdjacentListParams { RegionCode = "regionCode" };

        AdjacentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
