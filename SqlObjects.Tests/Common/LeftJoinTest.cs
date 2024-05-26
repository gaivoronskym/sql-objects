using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class LeftJoinTest
{
    [Fact]
    public void MakeSimpleJoin()
    {
        string expected = "LEFT JOIN [Inventories] _inventory ON _item.[Id] = _inventory.[ItemId]";

        Assert.Equal(
            expected,
            new LeftJoin("[Inventories] _inventory", "_item.[Id]", "_inventory.[ItemId]").Raw()
        );
    }
    
    [Fact]
    public void MakeSimpleJoinWithSubQuery()
    {
        string expected = "LEFT JOIN [Inventories] _inventory ON _item.[Id] = _inventory.[ItemId]\r\nAND _inventory.[Quantity] > 0";

        Assert.Equal(
            expected,
            new LeftJoin(
                "[Inventories] _inventory",
                "_item.[Id]",
                "_inventory.[ItemId]",
                new And(
                    new ExpressionOf("_inventory.[Quantity]", ">", 0)
                )
            ).Raw()
        );
    }
}