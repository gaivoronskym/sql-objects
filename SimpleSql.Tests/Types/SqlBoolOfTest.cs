using SimpleSql.Types;

namespace SimpleSql.Tests.Types;

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