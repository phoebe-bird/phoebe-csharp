using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Nearest;

public class GeoSpecieServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Nearest.GeoSpecies.List(
            "speciesCode",
            new() { Lat = -90, Lng = -180 }
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
