using Phoebe.Models.Product.Stats;

namespace Phoebe.Tests.Models.Product.Stats;

public class StatRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StatRetrieveResponse
        {
            NumChecklists = 0,
            NumContributors = 0,
            NumSpecies = 0,
        };

        int expectedNumChecklists = 0;
        int expectedNumContributors = 0;
        int expectedNumSpecies = 0;

        Assert.Equal(expectedNumChecklists, model.NumChecklists);
        Assert.Equal(expectedNumContributors, model.NumContributors);
        Assert.Equal(expectedNumSpecies, model.NumSpecies);
    }
}
