using Phoebe.Models.Ref.Taxonomy.Locales;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Locales;

public class LocaleListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocaleListResponse
        {
            Code = "en",
            LastUpdated = "2023-10-29 12:50",
            Name = "English",
        };

        string expectedCode = "en";
        string expectedLastUpdated = "2023-10-29 12:50";
        string expectedName = "English";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedLastUpdated, model.LastUpdated);
        Assert.Equal(expectedName, model.Name);
    }
}
