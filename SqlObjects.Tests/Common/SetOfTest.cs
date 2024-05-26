using SqlObjects.Servers.SqlServer;

namespace SqlObjects.Tests.Common;

public class SetOfTest
{
    [Fact]
    public void SetStringVariable()
    {
        string expected = "SET @name = 'John';";

        Assert.Equal(
            expected,
            new SetOf(
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
            new SetOf(
                "age",
                5
            ).Raw()
        );
    }
}