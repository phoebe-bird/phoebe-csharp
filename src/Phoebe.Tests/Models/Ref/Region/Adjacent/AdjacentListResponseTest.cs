using Phoebe.Models.Ref.Region.Adjacent;

namespace Phoebe.Tests.Models.Ref.Region.Adjacent;

public class AdjacentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AdjacentListResponse { Code = "US-CT", Name = "Connecticut" };

        string expectedCode = "US-CT";
        string expectedName = "Connecticut";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }
}
