﻿using ElegantSql.Types;

namespace Elegant.Tests.Types;

public class SqlDateOfTest
{
    [Fact]
    public void Act()
    {
        string expected = "'2024-05-01'";

        Assert.Equal(
            expected,
            new SqlDateOf(
                new DateTime(2024, 05, 01)
            ).Raw()
        );
    }
}