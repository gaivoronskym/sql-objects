using ElegantSql.Servers.SqlServer;

namespace Elegant.Tests.Common;

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