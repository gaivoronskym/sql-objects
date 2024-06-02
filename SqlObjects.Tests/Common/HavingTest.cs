using SqlObjects;
using SqlObjects.Common;
using SqlObjects.Servers.SqlServer;

namespace SqlObjects.Tests.Common;

public class HavingTest
{
    [Fact]
    public void Act()
    {
        string expected = "HAVING SUM([Amount]) > 0";

        Assert.Equal(
            expected,
            new Having(
                new Queries(
                    new Expression(
                        new Sum(
                            "[Amount]"
                        ),
                        ">",
                        0
                    )
                )
            ).Raw()
        );
    }
}