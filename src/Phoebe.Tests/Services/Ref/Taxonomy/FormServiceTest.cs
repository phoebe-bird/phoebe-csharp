using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Taxonomy;

public class FormServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        await this.client.Ref.Taxonomy.Forms.List(
            "speciesCode",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
