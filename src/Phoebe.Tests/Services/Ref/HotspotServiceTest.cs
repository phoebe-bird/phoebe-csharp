using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref;

public class HotspotServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var hotspots = await this.client.Ref.Hotspot.List("regionCode");
        foreach (var item in hotspots)
        {
            item.Validate();
        }
    }
}
