using ElegantSql;

namespace Elegant.Tests.Common;

public class RawSqlTest
{
    [Fact]
    public void MakeSqlQuery()
    {
        string expected = "SELECT * FROM [Users];";

        Assert.Equal(
            expected,
            new RawSql("SELECT * FROM [Users];").Raw()
        );
    }
}