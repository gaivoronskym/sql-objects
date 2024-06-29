using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class DeleteTest
{
    [Fact]
    public void Act()
    {
        string expected = "DELETE FROM [Books]\r\nWHERE [Id] = 1000;";

        Assert.Equal(
            expected,
            new Delete(
                "[Books]",
                new Where("[Id]", 1000)
            ).Raw()
        );
    }
}