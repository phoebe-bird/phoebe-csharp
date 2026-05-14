using System;
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

    [Fact]
    public void Url_Works()
    {
        SpeciesListListParams parameters = new() { RegionCode = "regionCode" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.ebird.org/v2/product/spplist/regionCode"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SpeciesListListParams { RegionCode = "regionCode" };

        SpeciesListListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
