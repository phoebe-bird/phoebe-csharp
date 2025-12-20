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
}
