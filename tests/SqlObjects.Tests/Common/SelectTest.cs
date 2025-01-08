using SqlObjects.Common;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Tests.Common;

public class SelectTest
{
    [Fact]
    public void TestSelectFirst()
    {
        string expected = new Joined(
            Environment.NewLine,
            "SELECT",
            "TOP(1)",
            "[Id],",
            "[Name]",
            "FROM [Items]"
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                new Queries(
                    new Top(1),
                    new Columns(
                        new ManyOf(
                            "[Id]",
                            "[Name]"
                        )
                    ),
                    new From("[Items]")
                )
            ).Sql()
        );
    }
    
    [Fact]
    public void MakeSimpleSelect()
    {
        string expected = new Joined(
            Environment.NewLine,
            "SELECT",
            "[Id],",
            "[Name]",
            "FROM [Items]"
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                new Queries(
                    new Columns(
                        new ManyOf(
                            "[Id]",
                            "[Name]"
                        )
                    ),
                    new From("[Items]")
                )
            ).Sql()
        );
    }

    [Fact]
    public void MakeSelectWithQuery()
    {
        string expected = new Trimmed(
            new Joined(
                Environment.NewLine,
                "SELECT",
                "_item.[Id],",
                "_item.[Name],",
                "SUM(_inventory.[Quantity]) AS [Quantity]",
                "FROM [Items] _item",
                "LEFT JOIN [Inventory] _inventory ON _item.[Id] = _inventory.[ItemId]",
                "GROUP BY _item.[Id], _item.[Name]"
            )
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                new Queries(
                    new QueryOf("_item.[Id]"),
                    new QueryOf("_item.[Name]"),
                    new Sum("_inventory.[Quantity]", "[Quantity]")
                ),
                "[Items] _item",
                new LeftJoin("[Inventory] _inventory", "_item.[Id]", "_inventory.[ItemId]"),
                new GroupBy("_item.[Id], _item.[Name]")
            ).Sql()
        );
    }
}