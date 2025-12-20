using Phoebe.Models.Product.Lists;

namespace Phoebe.Tests.Models.Product.Lists;

public class ListRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListRetrieveParams { RegionCode = "regionCode", MaxResults = 1 };

        string expectedRegionCode = "regionCode";
        long expectedMaxResults = 1;

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ListRetrieveParams { RegionCode = "regionCode" };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ListRetrieveParams
        {
            RegionCode = "regionCode",

            // Null should be interpreted as omitted for these properties
            MaxResults = null,
        };

        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
    }
}
