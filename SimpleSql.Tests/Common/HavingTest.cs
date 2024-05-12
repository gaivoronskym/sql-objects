using SimpleSql.Common;
using SimpleSql.Servers.SqlServer;

namespace SimpleSql.Tests.Common;

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
                    new Condition(
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