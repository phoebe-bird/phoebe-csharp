using System.Threading.Tasks;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Tests.Services.Ref.Taxonomy;

public class SpeciesGroupServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var speciesGroups = await this.client.Ref.Taxonomy.SpeciesGroups.List(
            SpeciesGrouping.Merlin,
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in speciesGroups)
        {
            item.Validate();
        }
    }
}
