using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Taxonomy;

public class VersionServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var versions = await this.client.Ref.Taxonomy.Versions.List();
        foreach (var item in versions)
        {
            item.Validate();
        }
    }
}
