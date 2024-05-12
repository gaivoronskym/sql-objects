using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class IsNotNullTest
{
    [Fact]
    public void Act()
    {
        string expected = "[Name] IS NOT NULL";

        Assert.Equal(
            expected,
            new IsNotNull("[Name]").Raw()
        );
    }
}