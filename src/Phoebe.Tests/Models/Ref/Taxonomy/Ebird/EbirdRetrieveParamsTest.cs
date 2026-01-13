using System;
using System.Text.Json;
using Phoebe.Core;
using Phoebe.Exceptions;
using Phoebe.Models.Ref.Taxonomy.Ebird;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Ebird;

public class EbirdRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EbirdRetrieveParams
        {
            Cat = "cat",
            Fmt = Fmt.Csv,
            Locale = "locale",
            Species = "species",
            Version = "version",
        };

        string expectedCat = "cat";
        ApiEnum<string, Fmt> expectedFmt = Fmt.Csv;
        string expectedLocale = "locale";
        string expectedSpecies = "species";
        string expectedVersion = "version";

        Assert.Equal(expectedCat, parameters.Cat);
        Assert.Equal(expectedFmt, parameters.Fmt);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedSpecies, parameters.Species);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EbirdRetrieveParams { };

        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
        Assert.Null(parameters.Species);
        Assert.False(parameters.RawQueryData.ContainsKey("species"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EbirdRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            Cat = null,
            Fmt = null,
            Locale = null,
            Species = null,
            Version = null,
        };

        Assert.Null(parameters.Cat);
        Assert.False(parameters.RawQueryData.ContainsKey("cat"));
        Assert.Null(parameters.Fmt);
        Assert.False(parameters.RawQueryData.ContainsKey("fmt"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
        Assert.Null(parameters.Species);
        Assert.False(parameters.RawQueryData.ContainsKey("species"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        EbirdRetrieveParams parameters = new()
        {
            Cat = "cat",
            Fmt = Fmt.Csv,
            Locale = "locale",
            Species = "species",
            Version = "version",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.ebird.org/v2/ref/taxonomy/ebird?cat=cat&fmt=csv&locale=locale&species=species&version=version"
            ),
            url
        );
    }
}

public class FmtTest : TestBase
{
    [Theory]
    [InlineData(Fmt.Csv)]
    [InlineData(Fmt.Json)]
    public void Validation_Works(Fmt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fmt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PhoebeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Fmt.Csv)]
    [InlineData(Fmt.Json)]
    public void SerializationRoundtrip_Works(Fmt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fmt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fmt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
