using System.Collections.Generic;
using Phoebe.Models.Ref.Taxonomy.Ebird;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Ebird;

public class EbirdRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EbirdRetrieveResponse
        {
            BandingCodes = ["string"],
            Category = "category",
            ComName = "comName",
            ComNameCodes = ["string"],
            FamilyCode = "familyCode",
            FamilyComName = "familyComName",
            FamilySciName = "familySciName",
            Order = "order",
            SciName = "sciName",
            SciNameCodes = ["string"],
            SpeciesCode = "speciesCode",
            TaxonOrder = 0,
        };

        List<string> expectedBandingCodes = ["string"];
        string expectedCategory = "category";
        string expectedComName = "comName";
        List<string> expectedComNameCodes = ["string"];
        string expectedFamilyCode = "familyCode";
        string expectedFamilyComName = "familyComName";
        string expectedFamilySciName = "familySciName";
        string expectedOrder = "order";
        string expectedSciName = "sciName";
        List<string> expectedSciNameCodes = ["string"];
        string expectedSpeciesCode = "speciesCode";
        int expectedTaxonOrder = 0;

        Assert.Equal(expectedBandingCodes.Count, model.BandingCodes.Count);
        for (int i = 0; i < expectedBandingCodes.Count; i++)
        {
            Assert.Equal(expectedBandingCodes[i], model.BandingCodes[i]);
        }
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedComName, model.ComName);
        Assert.Equal(expectedComNameCodes.Count, model.ComNameCodes.Count);
        for (int i = 0; i < expectedComNameCodes.Count; i++)
        {
            Assert.Equal(expectedComNameCodes[i], model.ComNameCodes[i]);
        }
        Assert.Equal(expectedFamilyCode, model.FamilyCode);
        Assert.Equal(expectedFamilyComName, model.FamilyComName);
        Assert.Equal(expectedFamilySciName, model.FamilySciName);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedSciName, model.SciName);
        Assert.Equal(expectedSciNameCodes.Count, model.SciNameCodes.Count);
        for (int i = 0; i < expectedSciNameCodes.Count; i++)
        {
            Assert.Equal(expectedSciNameCodes[i], model.SciNameCodes[i]);
        }
        Assert.Equal(expectedSpeciesCode, model.SpeciesCode);
        Assert.Equal(expectedTaxonOrder, model.TaxonOrder);
    }
}
