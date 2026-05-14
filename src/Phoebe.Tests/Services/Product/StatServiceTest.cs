using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product;

public class StatServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var stat = await this.client.Product.Stats.Retrieve(
            1,
            new()
            {
                RegionCode = "regionCode",
                Y = 0,
                M = 1,
            },
            TestContext.Current.CancellationToken
        );
        stat.Validate();
    }
}
