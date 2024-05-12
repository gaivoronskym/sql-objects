using SimpleSql.Types;

namespace SimpleSql.Tests.Types;

public class SqlStringOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "'John'";
        Assert.Equal(
            expected,
            new SqlStringOf("John").Raw()
        );
    }
}