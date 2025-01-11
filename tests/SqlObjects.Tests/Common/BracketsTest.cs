﻿using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.Tests.Common;

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
                new Condition("[Id]", 5)
            ).Sql()
        );
    }
}