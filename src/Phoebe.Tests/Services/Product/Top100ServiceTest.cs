using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product;

public class Top100ServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var top100s = await this.client.Product.Top100.Retrieve(
            1,
            new()
            {
                RegionCode = "regionCode",
                Y = 0,
                M = 1,
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in top100s)
        {
            item.Validate();
        }
    }
}
