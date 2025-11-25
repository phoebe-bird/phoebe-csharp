using System.Threading.Tasks;

namespace Phoebe.Tests.Services.Ref.Taxonomy;

public class LocaleServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var locales = await this.client.Ref.Taxonomy.Locales.List();
        foreach (var item in locales)
        {
            item.Validate();
        }
    }
}
