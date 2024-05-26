using SqlObjects.Types;

namespace SqlObjects.Tests.Types;

public class SqlDateTimeOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "'2024-05-01 09:05:00:000'";

        Assert.Equal(
            expected,
            new SqlDatetimeOf(
                new DateTime(2024, 05, 01, 9, 5, 0)
            ).Raw()
        );
    }
}