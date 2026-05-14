using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Region;

public class ListServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var lists = await this.client.Ref.Region.List.List(
            "parentRegionCode",
            new() { RegionType = "regionType" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in lists)
        {
            item.Validate();
        }
    }
}
