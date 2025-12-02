using Phoebe.Models.Ref.Taxonomy.Versions;

namespace Phoebe.Tests.Models.Ref.Taxonomy.Versions;

public class VersionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListResponse { AuthorityVer = 2017, Latest = true };

        double expectedAuthorityVer = 2017;
        bool expectedLatest = true;

        Assert.Equal(expectedAuthorityVer, model.AuthorityVer);
        Assert.Equal(expectedLatest, model.Latest);
    }
}
