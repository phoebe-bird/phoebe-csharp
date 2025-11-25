using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product.Lists;

public class HistoricalServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var historicals = await this.client.Product.Lists.Historical.Retrieve(
            1,
            new()
            {
                RegionCode = "regionCode",
                Y = 0,
                M = 1,
            }
        );
        foreach (var item in historicals)
        {
            item.Validate();
        }
    }
}
