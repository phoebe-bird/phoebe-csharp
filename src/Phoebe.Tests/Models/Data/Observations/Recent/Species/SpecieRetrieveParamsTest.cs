using System.Collections.Generic;
using Phoebe.Models.Data.Observations.Recent.Species;

namespace Phoebe.Tests.Models.Data.Observations.Recent.Species;

public class SpecieRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpecieRetrieveParams
        {
            RegionCode = "regionCode",
            SpeciesCode = "speciesCode",
            Back = 1,
            Hotspot = true,
            IncludeProvisional = true,
            MaxResults = 1,
            R = ["string"],
            SppLocale = "sppLocale",
        };

        string expectedRegionCode = "regionCode";
        string expectedSpeciesCode = "speciesCode";
        long expectedBack = 1;
        bool expectedHotspot = true;
        bool expectedIncludeProvisional = true;
        long expectedMaxResults = 1;
        List<string> expectedR = ["string"];
        string expectedSppLocale = "sppLocale";

        Assert.Equal(expectedRegionCode, parameters.RegionCode);
        Assert.Equal(expectedSpeciesCode, parameters.SpeciesCode);
        Assert.Equal(expectedBack, parameters.Back);
        Assert.Equal(expectedHotspot, parameters.Hotspot);
        Assert.Equal(expectedIncludeProvisional, parameters.IncludeProvisional);
        Assert.Equal(expectedMaxResults, parameters.MaxResults);
        Assert.NotNull(parameters.R);
        Assert.Equal(expectedR.Count, parameters.R.Count);
        for (int i = 0; i < expectedR.Count; i++)
        {
            Assert.Equal(expectedR[i], parameters.R[i]);
        }
        Assert.Equal(expectedSppLocale, parameters.SppLocale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpecieRetrieveParams
        {
            RegionCode = "regionCode",
            SpeciesCode = "speciesCode",
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpecieRetrieveParams
        {
            RegionCode = "regionCode",
            SpeciesCode = "speciesCode",

            // Null should be interpreted as omitted for these properties
            Back = null,
            Hotspot = null,
            IncludeProvisional = null,
            MaxResults = null,
            R = null,
            SppLocale = null,
        };

        Assert.Null(parameters.Back);
        Assert.False(parameters.RawQueryData.ContainsKey("back"));
        Assert.Null(parameters.Hotspot);
        Assert.False(parameters.RawQueryData.ContainsKey("hotspot"));
        Assert.Null(parameters.IncludeProvisional);
        Assert.False(parameters.RawQueryData.ContainsKey("includeProvisional"));
        Assert.Null(parameters.MaxResults);
        Assert.False(parameters.RawQueryData.ContainsKey("maxResults"));
        Assert.Null(parameters.R);
        Assert.False(parameters.RawQueryData.ContainsKey("r"));
        Assert.Null(parameters.SppLocale);
        Assert.False(parameters.RawQueryData.ContainsKey("sppLocale"));
    }
}
