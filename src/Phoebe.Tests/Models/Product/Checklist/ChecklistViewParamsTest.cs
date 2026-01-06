using System;
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

    [Fact]
    public void Url_Works()
    {
        ChecklistViewParams parameters = new() { SubID = "subId" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/product/checklist/view/subId"), url);
    }
}
