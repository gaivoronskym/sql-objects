using SqlObjects.Types;

namespace SqlObjects.Tests.Types;

public class SqlIntOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "1";

        Assert.Equal(
            expected,
            new SqlIntOf(1).Sql()
        );
    }
}