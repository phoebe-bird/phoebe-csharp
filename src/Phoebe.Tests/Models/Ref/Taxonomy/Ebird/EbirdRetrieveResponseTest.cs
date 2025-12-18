using System.Collections.Generic;
using System.Text.Json;
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

        Assert.NotNull(model.BandingCodes);
        Assert.Equal(expectedBandingCodes.Count, model.BandingCodes.Count);
        for (int i = 0; i < expectedBandingCodes.Count; i++)
        {
            Assert.Equal(expectedBandingCodes[i], model.BandingCodes[i]);
        }
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedComName, model.ComName);
        Assert.NotNull(model.ComNameCodes);
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
        Assert.NotNull(model.SciNameCodes);
        Assert.Equal(expectedSciNameCodes.Count, model.SciNameCodes.Count);
        for (int i = 0; i < expectedSciNameCodes.Count; i++)
        {
            Assert.Equal(expectedSciNameCodes[i], model.SciNameCodes[i]);
        }
        Assert.Equal(expectedSpeciesCode, model.SpeciesCode);
        Assert.Equal(expectedTaxonOrder, model.TaxonOrder);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EbirdRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EbirdRetrieveResponse>(element);
        Assert.NotNull(deserialized);

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

        Assert.NotNull(deserialized.BandingCodes);
        Assert.Equal(expectedBandingCodes.Count, deserialized.BandingCodes.Count);
        for (int i = 0; i < expectedBandingCodes.Count; i++)
        {
            Assert.Equal(expectedBandingCodes[i], deserialized.BandingCodes[i]);
        }
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedComName, deserialized.ComName);
        Assert.NotNull(deserialized.ComNameCodes);
        Assert.Equal(expectedComNameCodes.Count, deserialized.ComNameCodes.Count);
        for (int i = 0; i < expectedComNameCodes.Count; i++)
        {
            Assert.Equal(expectedComNameCodes[i], deserialized.ComNameCodes[i]);
        }
        Assert.Equal(expectedFamilyCode, deserialized.FamilyCode);
        Assert.Equal(expectedFamilyComName, deserialized.FamilyComName);
        Assert.Equal(expectedFamilySciName, deserialized.FamilySciName);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedSciName, deserialized.SciName);
        Assert.NotNull(deserialized.SciNameCodes);
        Assert.Equal(expectedSciNameCodes.Count, deserialized.SciNameCodes.Count);
        for (int i = 0; i < expectedSciNameCodes.Count; i++)
        {
            Assert.Equal(expectedSciNameCodes[i], deserialized.SciNameCodes[i]);
        }
        Assert.Equal(expectedSpeciesCode, deserialized.SpeciesCode);
        Assert.Equal(expectedTaxonOrder, deserialized.TaxonOrder);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EbirdRetrieveResponse { };

        Assert.Null(model.BandingCodes);
        Assert.False(model.RawData.ContainsKey("bandingCodes"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.ComName);
        Assert.False(model.RawData.ContainsKey("comName"));
        Assert.Null(model.ComNameCodes);
        Assert.False(model.RawData.ContainsKey("comNameCodes"));
        Assert.Null(model.FamilyCode);
        Assert.False(model.RawData.ContainsKey("familyCode"));
        Assert.Null(model.FamilyComName);
        Assert.False(model.RawData.ContainsKey("familyComName"));
        Assert.Null(model.FamilySciName);
        Assert.False(model.RawData.ContainsKey("familySciName"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.SciName);
        Assert.False(model.RawData.ContainsKey("sciName"));
        Assert.Null(model.SciNameCodes);
        Assert.False(model.RawData.ContainsKey("sciNameCodes"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.TaxonOrder);
        Assert.False(model.RawData.ContainsKey("taxonOrder"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EbirdRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EbirdRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            BandingCodes = null,
            Category = null,
            ComName = null,
            ComNameCodes = null,
            FamilyCode = null,
            FamilyComName = null,
            FamilySciName = null,
            Order = null,
            SciName = null,
            SciNameCodes = null,
            SpeciesCode = null,
            TaxonOrder = null,
        };

        Assert.Null(model.BandingCodes);
        Assert.False(model.RawData.ContainsKey("bandingCodes"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.ComName);
        Assert.False(model.RawData.ContainsKey("comName"));
        Assert.Null(model.ComNameCodes);
        Assert.False(model.RawData.ContainsKey("comNameCodes"));
        Assert.Null(model.FamilyCode);
        Assert.False(model.RawData.ContainsKey("familyCode"));
        Assert.Null(model.FamilyComName);
        Assert.False(model.RawData.ContainsKey("familyComName"));
        Assert.Null(model.FamilySciName);
        Assert.False(model.RawData.ContainsKey("familySciName"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.SciName);
        Assert.False(model.RawData.ContainsKey("sciName"));
        Assert.Null(model.SciNameCodes);
        Assert.False(model.RawData.ContainsKey("sciNameCodes"));
        Assert.Null(model.SpeciesCode);
        Assert.False(model.RawData.ContainsKey("speciesCode"));
        Assert.Null(model.TaxonOrder);
        Assert.False(model.RawData.ContainsKey("taxonOrder"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EbirdRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            BandingCodes = null,
            Category = null,
            ComName = null,
            ComNameCodes = null,
            FamilyCode = null,
            FamilyComName = null,
            FamilySciName = null,
            Order = null,
            SciName = null,
            SciNameCodes = null,
            SpeciesCode = null,
            TaxonOrder = null,
        };

        model.Validate();
    }
}
