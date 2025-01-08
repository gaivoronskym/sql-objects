using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class QueryOfTest
{
    [Fact]
    public void MakeSqlQuery()
    {
        string expected = "SELECT * FROM [Users];";

        Assert.Equal(
            expected,
            new QueryOf("SELECT * FROM [Users];").Sql()
        );
    }
}