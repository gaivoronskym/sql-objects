﻿using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class OrTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "OR [Id] = 1";

        Assert.Equal(
            expected,
            new Or(
                new Condition("[Id]", 1)
            ).Raw()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "OR [Id] > 1";

        Assert.Equal(
            expected,
            new Or(
                new Condition("[Id]", ">", 1)
            ).Raw()
        );
    }
}