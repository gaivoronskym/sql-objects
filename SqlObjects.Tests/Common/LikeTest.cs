﻿using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class LikeTest
{
    [Fact]
    public void Act()
    {
        string expected = "[Name] LIKE '%Jo%'";

        Assert.Equal(
            expected,
            new Like(
                "[Name]",
                "Jo"
            ).Raw()
        );
    }
}