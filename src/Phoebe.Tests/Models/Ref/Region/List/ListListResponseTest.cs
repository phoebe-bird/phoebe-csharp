using Phoebe.Models.Ref.Region.List;

namespace Phoebe.Tests.Models.Ref.Region.List;

public class ListListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListListResponse { Code = "US-NY", Name = "New York" };

        string expectedCode = "US-NY";
        string expectedName = "New York";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }
}
