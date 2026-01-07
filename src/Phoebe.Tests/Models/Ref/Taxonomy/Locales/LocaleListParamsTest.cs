using System;
using System.Net.Http;
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

    [Fact]
    public void Url_Works()
    {
        LocaleListParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.ebird.org/v2/ref/taxa-locales/ebird"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LocaleListParams parameters = new() { AcceptLanguage = "en" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["en"], requestMessage.Headers.GetValues("Accept-Language"));
    }
}
