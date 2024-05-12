using SimpleSql.Servers.SqlServer;

namespace SimpleSql.Tests.Common;

public class DeclareOfTest
{
    [Fact]
    public void MakeSqlVariable()
    {
        string expected = "DECLARE @name NVARCHAR(30);";

        Assert.Equal(
            expected,
            new DeclareOf(
                "name",
                "NVARCHAR(30)"
            ).Raw()
        );
    }
}