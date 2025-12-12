using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Recent;

public class NotableServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Recent.Notable.List(
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
