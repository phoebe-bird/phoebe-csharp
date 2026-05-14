using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Region;

public class InfoServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var info = await this.client.Ref.Region.Info.Retrieve(
            "regionCode",
            new(),
            TestContext.Current.CancellationToken
        );
        info.Validate();
    }
}
