using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class IsNotNullTest
{
    [Fact]
    public void Act()
    {
        string expected = "[Name] IS NOT NULL";

        Assert.Equal(
            expected,
            new IsNotNull("[Name]").Sql()
        );
    }
}