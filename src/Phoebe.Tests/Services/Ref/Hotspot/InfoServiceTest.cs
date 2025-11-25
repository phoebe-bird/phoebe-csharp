using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Hotspot;

public class InfoServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var info = await this.client.Ref.Hotspot.Info.Retrieve("locId");
        info.Validate();
    }
}
