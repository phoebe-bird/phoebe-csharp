using Phoebe.Models.Data.Observations.Nearest.GeoSpecies;

namespace Phoebe.Tests.Models.Data.Observations.Nearest.GeoSpecies;

public class GeoSpecieListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GeoSpecieListParams
        {
            SpeciesCode = "speciesCode",
            Lat = -90,
            Lng = -180,
            Back = 1,
            Dist = 0,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            SppLocale = "sppLocale",
        };

        string expectedSpeciesCode = "speciesCode";
        float expectedLat = -90;
        float expectedLng = -180;
        long expectedBack = 1;
        long expectedDist = 0;
        bool expectedHotspot = true;
        bool expectedIncludeProvisional = true;
        long expectedMaxResults = 1;
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedSpeciesCode, parameters.SpeciesCode);
        Assert.Equal(expectedLat, parameters.Lat);
        Assert.Equal(expectedLng, parameters.Lng);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedDist, parameters.Dist);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedIncludeProvisional, parameters.IncludeProvisional);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeoSpecieListParams
        {
            SpeciesCode = "speciesCode",
            Lat = -90,
            Lng = -180,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GeoSpecieListParams
        {
            SpeciesCode = "speciesCode",
            Lat = -90,
            Lng = -180,

            // Null should be interpreted as omitted for these properties
            Back = null,
            Dist = null,
            Hotspot = null,
            IncludeProvisional = null,
            MaxResults = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Dist);
        Assert.False(parameters.RawQueryData.ContainsKey("dist"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }
}
