using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product;

public class ChecklistServiceTest : TestBase
{
    [Fact]
    public async Task View_Works()
    {
        var response = await this.client.Product.Checklist.View("subId");
        response.Validate();
    }
}
