using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class InnerJoinTest
{
    [Fact]
    public void MakeSimpleJoin()
    {
        string expected = "INNER JOIN [Inventories] _inventory ON _item.[Id] = _inventory.[ItemId]";

        Assert.Equal(
            expected,
            new InnerJoin("[Inventories] _inventory", "_item.[Id]", "_inventory.[ItemId]").Raw()
        );
    }
    
    [Fact]
    public void MakeSimpleJoinWithSubQuery()
    {
        string expected = "INNER JOIN [Inventories] _inventory ON _item.[Id] = _inventory.[ItemId]\r\nAND _inventory.[Quantity] > 0";

        Assert.Equal(
            expected,
            new InnerJoin(
                "[Inventories] _inventory",
                "_item.[Id]",
                "_inventory.[ItemId]",
                new And(
                    new Condition("_inventory.[Quantity]", ">", 0)
                )
            ).Raw()
        );
    }
}