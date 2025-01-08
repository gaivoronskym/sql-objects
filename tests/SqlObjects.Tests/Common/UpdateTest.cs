using SqlObjects.Common;
using Record = SqlObjects.Common.Record;

namespace SqlObjects.Tests.Common;

public class UpdateTest
{
    [Fact]
    public void MakeSimpleUpdate()
    {
        string expected = "UPDATE [Books] SET [AuthorId] = 5;";

        Assert.Equal(
            expected,
            new Update(
                "[Books]",
                new Record(
                    new SqlParam(
                        "[AuthorId]",
                        5
                    )
                )
            ).Sql()
        );
    }
    
    [Fact]
    public void MakeUpdate()
    {
        string expected = "UPDATE [Books] SET [AuthorId] = 5,[PublisherId] = 10\r\nWHERE\r\n[Id] = 100;";

        Assert.Equal(
            expected,
            new Update(
                "[Books]",
                new Record(
                    new SqlParam(
                        "[AuthorId]",
                        5
                    ),
                    new SqlParam(
                        "[PublisherId]",
                        10
                    )
                ),
                new Queries(
                    new Where(
                        new Condition(
                            "[Id]",
                            100
                        )
                    )
                )
            ).Sql()
        );
    }
}