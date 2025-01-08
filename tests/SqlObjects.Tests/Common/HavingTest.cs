using SqlObjects.Common;

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
                    new Condition(
                        new Sum(
                            "[Amount]"
                        ),
                        ">",
                        0
                    )
                )
            ).Sql()
        );
    }
}