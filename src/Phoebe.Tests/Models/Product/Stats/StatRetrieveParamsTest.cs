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
}
