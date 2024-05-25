﻿using ElegantSql.Common;
using Yaapii.Atoms.Text;

namespace Elegant.Tests.Common;

public class BracketsTest
{
    [Fact]
    public void Act()
    {
        string expected = new Joined(
            Environment.NewLine,
            "(",
            "[Id] = 5",
            ")"
        ).AsString();

        Assert.Equal(
            expected,
            new Brackets(
                new ExpressionOf("[Id]", 5)
            ).Raw()
        );
    }
}