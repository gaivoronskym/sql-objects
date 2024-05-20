using ElegantSql.Types;

namespace Elegant.Tests.Types;

public class SqlIntOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "1";

        Assert.Equal(
            expected,
            new SqlIntOf(1).Raw()
        );
    }
}