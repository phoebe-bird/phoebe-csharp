using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Region;

public class AdjacentServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var adjacents = await this.client.Ref.Region.Adjacent.List(
            "regionCode",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in adjacents)
        {
            item.Validate();
        }
    }
}
