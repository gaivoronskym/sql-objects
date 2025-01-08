using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class DeclareOfTest
{
    [Fact]
    public void MakeSqlVariable()
    {
        string expected = "DECLARE @name NVARCHAR(30);";

        Assert.Equal(
            expected,
            new Declare(
                "name",
                "NVARCHAR(30)"
            ).Sql()
        );
    }
}