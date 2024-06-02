using SqlObjects.Common;
using SqlObjects.Interfaces;
using SqlObjects.Servers.SqlServer;
using Yaapii.Atoms.List;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Tests.Common;

public class InsertTest
{
    [Fact]
    public void MakeSimpleInsert()
    {
        string expected = new Joined(
            Environment.NewLine,
            "INSERT INTO [Items]",
            "([Name], [Cost])",
            "VALUES",
            "('Apple iPhone', 1000.0);"
        ).AsString();


        Assert.Equal(
            expected,
            new Insert(
                "[Items]",
                new Record(
                    new SqlParam(
                        "[Name]", "Apple iPhone"
                    ),
                    new SqlParam(
                        "[Cost]", 1000.0m
                    )
                )
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeSimpleInsertWithScopeIdentity()
    {
        string expected = new Joined(
            Environment.NewLine,
            "INSERT INTO [Items]",
            "([Name], [Cost])",
            "VALUES",
            "('Apple iPhone', 1000.0)",
            "SELECT scope_identity() as Id;"
        ).AsString();


        Assert.Equal(
            expected,
            new Insert(
                "[Items]",
                new Queries(
                    new Records(
                        new Record(
                            new SqlParam(
                                "[Name]", "Apple iPhone"
                            ),
                            new SqlParam(
                                "[Cost]", 1000.0m
                            )
                        )
                    ),
                    new ScopeIdentity()
                )
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeBulkInsert()
    {
        string expected = new Joined(
            Environment.NewLine,
            "INSERT INTO [Items]",
            "([Name], [Cost])",
            "VALUES",
            "('Apple iPhone', 1000.0),",
            "('Samsung Galaxy S', 990.0);"
        ).AsString();


        Assert.Equal(
            expected,
            new Insert(
                "[Items]",
                new Queries(
                    new Records(
                        new ListOf<IRecord>(
                            new Record(
                                new SqlParam(
                                    "[Name]", "Apple iPhone"
                                ),
                                new SqlParam(
                                    "[Cost]", 1000.0m
                                )
                            ),
                            new Record(
                                new SqlParam(
                                    "[Name]", "Samsung Galaxy S"
                                ),
                                new SqlParam(
                                    "[Cost]", 990.0m
                                )
                            )
                        )
                    )
                )
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeInsertIds()
    {
        string expected = new Joined(
            Environment.NewLine,
            "INSERT INTO @ids",
            "([Id])",
            "VALUES",
            "(1),",
            "(2),",
            "(3),",
            "(4),",
            "(5);"
        ).AsString();

        Assert.Equal(
            expected,
            new Insert(
                "@ids",
                "[Id]",
                new ListOf<int>(1, 2, 3, 4, 5)
            ).Raw()
        );
    }
}