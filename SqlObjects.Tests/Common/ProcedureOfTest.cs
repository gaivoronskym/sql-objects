using SqlObjects;
using SqlObjects.Common;
using SqlObjects.Servers.SqlServer;
using Yaapii.Atoms.List;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Tests.Common;

public class ProcedureOfTest
{
    [Fact]
    public void Act()
    {
        string expected = new Joined(
            Environment.NewLine,
            "DECLARE @ids [dbo].[Ids];",
            "INSERT INTO @ids ([Id])",
            "VALUES",
            "(1),",
            "(2),",
            "(3),",
            "(4),",
            "(5),",
            "(6),",
            "(7),",
            "(8),",
            "(9),",
            "(10);",
            "EXEC [SearchItems]",
            "@ids = @ids,",
            "@name = '0316',",
            "@skip = 0,",
            "@take = 500;"
        ).AsString();

        Assert.Equal(
            expected,
            new QueryOf(
                new DeclareOf("ids", "[dbo].[Ids]"),
                new Insert(
                    "@ids",
                    "[Id]",
                    new ListOf<long>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)
                ),
                new ProcedureOf(
                    "[SearchItems]",
                    new SqlParamsOf(
                        new SqlParam("ids", new RawSql("@ids")),
                        new SqlParam("name", "0316"),
                        new SqlParam("skip", 0),
                        new SqlParam("take", 500)
                    )
                )
            ).Raw()
        );
    }
}