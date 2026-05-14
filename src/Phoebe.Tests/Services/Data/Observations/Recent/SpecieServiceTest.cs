using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Recent;

public class SpecieServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var observations = await this.client.Data.Observations.Recent.Species.Retrieve(
            "speciesCode",
            new() { RegionCode = "regionCode" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
