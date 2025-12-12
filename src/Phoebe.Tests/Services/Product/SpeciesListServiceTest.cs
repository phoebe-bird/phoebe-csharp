using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Product;

public class SpeciesListServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        await this.client.Product.SpeciesList.List(
            "regionCode",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
