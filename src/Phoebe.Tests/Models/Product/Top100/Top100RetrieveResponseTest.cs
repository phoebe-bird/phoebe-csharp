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
}
