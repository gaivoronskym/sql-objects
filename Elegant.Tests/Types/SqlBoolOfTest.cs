using ElegantSql.Types;

namespace Elegant.Tests.Types;

public class SqlBoolOfTest
{
    [Fact]
    public void TestTrue()
    {
        string expected = "1";

        Assert.Equal(
            expected,
            new SqlBoolOf(true).Raw()
        );
    }
    
    [Fact]
    public void TestFalse()
    {
        string expected = "0";

        Assert.Equal(
            expected,
            new SqlBoolOf(false).Raw()
        );
    }
}