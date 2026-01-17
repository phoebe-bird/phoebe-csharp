using System;
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

    [Fact]
    public void Url_Works()
    {
        InfoRetrieveParams parameters = new() { LocID = "locId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/ref/hotspot/info/locId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InfoRetrieveParams { LocID = "locId" };

        InfoRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
