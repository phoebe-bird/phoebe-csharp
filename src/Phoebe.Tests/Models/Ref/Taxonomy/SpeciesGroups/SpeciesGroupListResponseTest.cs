using System.Collections.Generic;
using System.Text.Json;
using Phoebe.Core;
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
        Assert.NotNull(model.TaxonOrderBounds);
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpeciesGroupListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpeciesGroupListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedGroupName = "Waterfowl";
        long expectedGroupOrder = 1;
        List<List<float>> expectedTaxonOrderBounds =
        [
            [211, 579],
            [1968, 2063],
            [16549, 16613],
        ];

        Assert.Equal(expectedGroupName, deserialized.GroupName);
        Assert.Equal(expectedGroupOrder, deserialized.GroupOrder);
        Assert.NotNull(deserialized.TaxonOrderBounds);
        Assert.Equal(expectedTaxonOrderBounds.Count, deserialized.TaxonOrderBounds.Count);
        for (int i = 0; i < expectedTaxonOrderBounds.Count; i++)
        {
            Assert.Equal(expectedTaxonOrderBounds[i].Count, deserialized.TaxonOrderBounds[i].Count);
            for (int i1 = 0; i1 < expectedTaxonOrderBounds[i].Count; i1++)
            {
                Assert.Equal(expectedTaxonOrderBounds[i][i1], deserialized.TaxonOrderBounds[i][i1]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SpeciesGroupListResponse { };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("groupName"));
        Assert.Null(model.GroupOrder);
        Assert.False(model.RawData.ContainsKey("groupOrder"));
        Assert.Null(model.TaxonOrderBounds);
        Assert.False(model.RawData.ContainsKey("taxonOrderBounds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SpeciesGroupListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SpeciesGroupListResponse
        {
            // Null should be interpreted as omitted for these properties
            GroupName = null,
            GroupOrder = null,
            TaxonOrderBounds = null,
        };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("groupName"));
        Assert.Null(model.GroupOrder);
        Assert.False(model.RawData.ContainsKey("groupOrder"));
        Assert.Null(model.TaxonOrderBounds);
        Assert.False(model.RawData.ContainsKey("taxonOrderBounds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SpeciesGroupListResponse
        {
            // Null should be interpreted as omitted for these properties
            GroupName = null,
            GroupOrder = null,
            TaxonOrderBounds = null,
        };

        model.Validate();
    }
}
