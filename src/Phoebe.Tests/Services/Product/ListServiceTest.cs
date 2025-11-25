using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product;

public class ListServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var lists = await this.client.Product.Lists.Retrieve("regionCode");
        foreach (var item in lists)
        {
            item.Validate();
        }
    }
}
