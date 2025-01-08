using SqlObjects.Types;

namespace SqlObjects.Tests.Types;

public class SqlStringOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "'John'";
        Assert.Equal(
            expected,
            new SqlStringOf("John").Sql()
        );
    }
}