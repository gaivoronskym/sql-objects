using ElegantSql;
using ElegantSql.Common;
using ElegantSql.Servers.SqlServer;

namespace Elegant.Tests.Common;

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
                    new ExpressionOf(
                        new SumOf(
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