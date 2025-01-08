using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class DeleteTest
{
    [Fact]
    public void Act()
    {
        var expected = "DELETE FROM [Books]\r\nWHERE\r\n[Id] = 1000;";

        Assert.Equal(
            expected,
            new Delete(
                "[Books]",
                new Where("[Id]", 1000)
            ).Sql()
        );
    }
}