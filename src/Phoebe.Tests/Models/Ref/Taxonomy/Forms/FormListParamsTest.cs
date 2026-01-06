using System;
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

    [Fact]
    public void Url_Works()
    {
        FormListParams parameters = new() { SpeciesCode = "speciesCode" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/ref/taxon/forms/speciesCode"), url);
    }
}
