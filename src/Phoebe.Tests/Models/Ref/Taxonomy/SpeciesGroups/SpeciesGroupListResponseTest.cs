using System.Collections.Generic;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;

namespace Phoebe.Tests.Models.Ref.Taxonomy.SpeciesGroups;

public class SpeciesGroupListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpeciesGroupListResponse
        {
            GroupName = "Waterfowl",
            GroupOrder = 1,
            TaxonOrderBounds =
            [
                [211, 579],
                [1968, 2063],
                [16549, 16613],
            ],
        };

        string expectedGroupName = "Waterfowl";
        long expectedGroupOrder = 1;
        List<List<float>> expectedTaxonOrderBounds =
        [
            [211, 579],
            [1968, 2063],
            [16549, 16613],
        ];

        Assert.Equal(expectedGroupName, model.GroupName);
        Assert.Equal(expectedGroupOrder, model.GroupOrder);
        Assert.Equal(expectedTaxonOrderBounds.Count, model.TaxonOrderBounds.Count);
        for (int i = 0; i < expectedTaxonOrderBounds.Count; i++)
        {
            Assert.Equal(expectedTaxonOrderBounds[i].Count, model.TaxonOrderBounds[i].Count);
            for (int i1 = 0; i1 < expectedTaxonOrderBounds[i].Count; i1++)
            {
                Assert.Equal(expectedTaxonOrderBounds[i][i1], model.TaxonOrderBounds[i][i1]);
            }
        }
    }
}
