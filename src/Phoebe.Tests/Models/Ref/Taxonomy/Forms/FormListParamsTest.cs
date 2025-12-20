using Phoebe.Models.Ref.Taxonomy.Forms;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Forms;

public class FormListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FormListParams { SpeciesCode = "speciesCode" };

        string expectedSpeciesCode = "speciesCode";

        Assert.Equal(expectedSpeciesCode, parameters.SpeciesCode);
    }
}
