using Phoebe.Models.Product.Checklist;

namespace Phoebe.Tests.Models.Product.Checklist;

public class ChecklistViewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChecklistViewParams { SubID = "subId" };

        string expectedSubID = "subId";

        Assert.Equal(expectedSubID, parameters.SubID);
    }
}
