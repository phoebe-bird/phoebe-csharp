using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations;

public class RecentServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Recent.List(
            "regionCode",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
