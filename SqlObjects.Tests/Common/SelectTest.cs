using SqlObjects;
using SqlObjects.Common;
using SqlObjects.Servers.SqlServer;
using Yaapii.Atoms.Text;
using SumOf = SqlObjects.Common.SumOf;

namespace SqlObjects.Tests.Common;

public class SelectTest
{
    [Fact]
    public void TestSelectFirst()
    {
        string expected = new Joined(
            Environment.NewLine,
            "SELECT TOP(1)",
            "[Id], [Name]",
            "FROM [Items];"
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                "[Items]",
                new Top(1),
                new Columns(
                    "[Id]",
                    "[Name]"
                )
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeSimpleSelect()
    {
        string expected = new Joined(
            Environment.NewLine,
            "SELECT",
            "[Id], [Name]",
            "FROM [Items];"
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                "[Items]",
                new Columns(
                    "[Id]",
                    "[Name]"
                )
            ).Raw()
        );
    }

    [Fact]
    public void MakeSelectWithQuery()
    {
        string expected = new Trimmed(
            new Joined(
                Environment.NewLine,
                "SELECT",
                "_item.[Id], _item.[Name], SUM(_inventory.[Quantity]) AS [Quantity]",
                "FROM [Items] _item",
                "LEFT JOIN [Inventory] _inventory ON _item.[Id] = _inventory.[ItemId]",
                "GROUP BY _item.[Id], _item.[Name];"
            )
        ).AsString();

        Assert.Equal(
            expected,
            new Select(
                "[Items] _item",
                new Columns(
                    new RawSql("_item.[Id]"),
                    new RawSql("_item.[Name]"),
                    new SumOf("_inventory.[Quantity]", "[Quantity]")
                ),
                new Queries(
                    new LeftJoin("[Inventory] _inventory", "_item.[Id]", "_inventory.[ItemId]"),
                    new GroupBy("_item.[Id], _item.[Name]")
                )
            ).Raw()
        );
    }
}