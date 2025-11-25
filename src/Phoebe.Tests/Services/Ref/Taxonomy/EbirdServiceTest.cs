using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Taxonomy;

public class EbirdServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var ebirds = await this.client.Ref.Taxonomy.Ebird.Retrieve();
        foreach (var item in ebirds)
        {
            item.Validate();
        }
    }
}
