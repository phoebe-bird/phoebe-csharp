using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Data.Observations.Recent;

public class HistoricServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var observations = await this.client.Data.Observations.Recent.Historic.List(
            1,
            new()
            {
                RegionCode = "regionCode",
                Y = 0,
                M = 1,
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in observations)
        {
            item.Validate();
        }
    }
}
