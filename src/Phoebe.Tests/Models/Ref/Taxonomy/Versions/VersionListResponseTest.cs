using System.Text.Json;
using Phoebe.Models.Ref.Taxonomy.Versions;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Versions;

public class VersionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListResponse { AuthorityVer = 2017, Latest = true };

        double expectedAuthorityVer = 2017;
        bool expectedLatest = true;

        Assert.Equal(expectedAuthorityVer, model.AuthorityVer);
        Assert.Equal(expectedLatest, model.Latest);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionListResponse { AuthorityVer = 2017, Latest = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VersionListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionListResponse { AuthorityVer = 2017, Latest = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VersionListResponse>(json);
        Assert.NotNull(deserialized);

        double expectedAuthorityVer = 2017;
        bool expectedLatest = true;

        Assert.Equal(expectedAuthorityVer, deserialized.AuthorityVer);
        Assert.Equal(expectedLatest, deserialized.Latest);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionListResponse { AuthorityVer = 2017, Latest = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VersionListResponse { };

        Assert.Null(model.AuthorityVer);
        Assert.False(model.RawData.ContainsKey("authorityVer"));
        Assert.Null(model.Latest);
        Assert.False(model.RawData.ContainsKey("latest"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VersionListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VersionListResponse
        {
            // Null should be interpreted as omitted for these properties
            AuthorityVer = null,
            Latest = null,
        };

        Assert.Null(model.AuthorityVer);
        Assert.False(model.RawData.ContainsKey("authorityVer"));
        Assert.Null(model.Latest);
        Assert.False(model.RawData.ContainsKey("latest"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VersionListResponse
        {
            // Null should be interpreted as omitted for these properties
            AuthorityVer = null,
            Latest = null,
        };

        model.Validate();
    }
}
