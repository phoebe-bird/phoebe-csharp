using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Geo.Recent;

public class NotableServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Geo.Recent.Notable.List(
            new() { Lat = -90, Lng = -180 }
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
