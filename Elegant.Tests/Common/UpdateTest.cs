using ElegantSql;
using ElegantSql.Common;

namespace Elegant.Tests.Common;

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
                new SqlParamsOf(
                    new SqlParam(
                        "[AuthorId]",
                        5
                    )
                )
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeUpdate()
    {
        string expected = "UPDATE [Books] SET [AuthorId] = 5,[PublisherId] = 10\r\nWHERE [Id] = 100;";

        Assert.Equal(
            expected,
            new Update(
                "[Books]",
                new SqlParamsOf(
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
                        new ExpressionOf(
                            "[Id]",
                            100
                        )
                    )
                )
            ).Raw()
        );
    }
}