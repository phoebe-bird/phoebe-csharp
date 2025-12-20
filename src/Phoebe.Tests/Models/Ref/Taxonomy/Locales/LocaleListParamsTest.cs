using Phoebe.Models.Ref.Taxonomy.Locales;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Locales;

public class LocaleListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LocaleListParams { AcceptLanguage = "en" };

        string expectedAcceptLanguage = "en";

        Assert.Equal(expectedAcceptLanguage, parameters.AcceptLanguage);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LocaleListParams { };

        Assert.Null(parameters.AcceptLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("Accept-Language"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LocaleListParams
        {
            // Null should be interpreted as omitted for these properties
            AcceptLanguage = null,
        };

        Assert.Null(parameters.AcceptLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("Accept-Language"));
    }
}
