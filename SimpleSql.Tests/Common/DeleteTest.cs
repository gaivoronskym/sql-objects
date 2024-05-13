using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

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
                new Where(
                    new ExpressionOf(
                        "[Id]",
                        1000
                    )
                )
            ).Raw()
        );
    }
}