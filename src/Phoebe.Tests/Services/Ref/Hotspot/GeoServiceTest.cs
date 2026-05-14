using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Hotspot;

public class GeoServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var geos = await this.client.Ref.Hotspot.Geo.Retrieve(
            new() { Lat = -90, Lng = -180 },
            TestContext.Current.CancellationToken
        );
        foreach (var item in geos)
        {
            item.Validate();
        }
    }
}
