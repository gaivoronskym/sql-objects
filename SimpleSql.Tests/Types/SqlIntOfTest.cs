using SimpleSql.Types;

namespace SimpleSql.Tests.Types;

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