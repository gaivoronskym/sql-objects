using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class LikeTest
{
    [Fact]
    public void Act()
    {
        string expected = "[Name] LIKE '%Jo%'";

        Assert.Equal(
            expected,
            new Like(
                "[Name]",
                "Jo"
            ).Raw()
        );
    }
}