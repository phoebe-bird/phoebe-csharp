using Phoebe.Models.Ref.Hotspot.Info;

namespace Phoebe.Tests.Models.Ref.Hotspot.Info;

public class InfoRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InfoRetrieveParams { LocID = "locId" };

        string expectedLocID = "locId";

        Assert.Equal(expectedLocID, parameters.LocID);
    }
}
