using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Geo;

public class RecentServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Geo.Recent.List(
            new() { Lat = -90, Lng = -180 },
            TestContext.Current.CancellationToken
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
