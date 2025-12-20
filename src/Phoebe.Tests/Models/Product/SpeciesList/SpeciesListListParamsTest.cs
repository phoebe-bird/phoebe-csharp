using Phoebe.Models.Product.SpeciesList;

namespace Phoebe.Tests.Models.Product.SpeciesList;

public class SpeciesListListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpeciesListListParams { RegionCode = "regionCode" };

        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
    }
}
