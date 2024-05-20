using ElegantSql.Common;

namespace Elegant.Tests.Common;

public class IsNullTest
{
    [Fact]
    public void Act()
    {
        string expected = "[Name] IS NULL";

        Assert.Equal(
            expected,
            new IsNull("[Name]").Raw()
        );
    }
}