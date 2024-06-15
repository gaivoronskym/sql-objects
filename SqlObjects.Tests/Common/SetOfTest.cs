using SqlObjects.SqlServer;

namespace SqlObjects.Tests.Common;

public class SetOfTest
{
    [Fact]
    public void SetStringVariable()
    {
        string expected = "SET @name = 'John';";

        Assert.Equal(
            expected,
            new Set(
                "name",
                "John"
            ).Raw()
        );
    }
    
    [Fact]
    public void SetIntegerVariable()
    {
        string expected = "SET @age = 5;";

        Assert.Equal(
            expected,
            new Set(
                "age",
                5
            ).Raw()
        );
    }
}