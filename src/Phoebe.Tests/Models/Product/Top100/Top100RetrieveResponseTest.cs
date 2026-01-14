using System.Text.Json;
using Phoebe.Core;
using Phoebe.Models.Product.Top100;

namespace Phoebe.Tests.Models.Product.Top100;

public class Top100RetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Top100RetrieveResponse
        {
            NumCompleteChecklists = 0,
            NumSpecies = 0,
            ProfileHandle = "profileHandle",
            RowNum = 0,
            UserDisplayName = "userDisplayName",
            UserID = "userId",
        };

        int expectedNumCompleteChecklists = 0;
        int expectedNumSpecies = 0;
        string expectedProfileHandle = "profileHandle";
        int expectedRowNum = 0;
        string expectedUserDisplayName = "userDisplayName";
        string expectedUserID = "userId";

        Assert.Equal(expectedNumCompleteChecklists, model.NumCompleteChecklists);
        Assert.Equal(expectedNumSpecies, model.NumSpecies);
        Assert.Equal(expectedProfileHandle, model.ProfileHandle);
        Assert.Equal(expectedRowNum, model.RowNum);
        Assert.Equal(expectedUserDisplayName, model.UserDisplayName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Top100RetrieveResponse
        {
            NumCompleteChecklists = 0,
            NumSpecies = 0,
            ProfileHandle = "profileHandle",
            RowNum = 0,
            UserDisplayName = "userDisplayName",
            UserID = "userId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Top100RetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Top100RetrieveResponse
        {
            NumCompleteChecklists = 0,
            NumSpecies = 0,
            ProfileHandle = "profileHandle",
            RowNum = 0,
            UserDisplayName = "userDisplayName",
            UserID = "userId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Top100RetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedNumCompleteChecklists = 0;
        int expectedNumSpecies = 0;
        string expectedProfileHandle = "profileHandle";
        int expectedRowNum = 0;
        string expectedUserDisplayName = "userDisplayName";
        string expectedUserID = "userId";

        Assert.Equal(expectedNumCompleteChecklists, deserialized.NumCompleteChecklists);
        Assert.Equal(expectedNumSpecies, deserialized.NumSpecies);
        Assert.Equal(expectedProfileHandle, deserialized.ProfileHandle);
        Assert.Equal(expectedRowNum, deserialized.RowNum);
        Assert.Equal(expectedUserDisplayName, deserialized.UserDisplayName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Top100RetrieveResponse
        {
            NumCompleteChecklists = 0,
            NumSpecies = 0,
            ProfileHandle = "profileHandle",
            RowNum = 0,
            UserDisplayName = "userDisplayName",
            UserID = "userId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Top100RetrieveResponse { };

        Assert.Null(model.NumCompleteChecklists);
        Assert.False(model.RawData.ContainsKey("numCompleteChecklists"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
        Assert.Null(model.ProfileHandle);
        Assert.False(model.RawData.ContainsKey("profileHandle"));
        Assert.Null(model.RowNum);
        Assert.False(model.RawData.ContainsKey("rowNum"));
        Assert.Null(model.UserDisplayName);
        Assert.False(model.RawData.ContainsKey("userDisplayName"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Top100RetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Top100RetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            NumCompleteChecklists = null,
            NumSpecies = null,
            ProfileHandle = null,
            RowNum = null,
            UserDisplayName = null,
            UserID = null,
        };

        Assert.Null(model.NumCompleteChecklists);
        Assert.False(model.RawData.ContainsKey("numCompleteChecklists"));
        Assert.Null(model.NumSpecies);
        Assert.False(model.RawData.ContainsKey("numSpecies"));
        Assert.Null(model.ProfileHandle);
        Assert.False(model.RawData.ContainsKey("profileHandle"));
        Assert.Null(model.RowNum);
        Assert.False(model.RawData.ContainsKey("rowNum"));
        Assert.Null(model.UserDisplayName);
        Assert.False(model.RawData.ContainsKey("userDisplayName"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Top100RetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            NumCompleteChecklists = null,
            NumSpecies = null,
            ProfileHandle = null,
            RowNum = null,
            UserDisplayName = null,
            UserID = null,
        };

        model.Validate();
    }
}
