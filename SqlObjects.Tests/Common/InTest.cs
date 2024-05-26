using SqlObjects.Common;
using Yaapii.Atoms.List;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Tests.Common;

public class InTest
{
    [Fact]
    public void Act()
    {
        string expected = new Joined(
            Environment.NewLine,
            "[Id] IN (",
            "1,2,3,4,5",
            ")"
        ).AsString();

        Assert.Equal(
            expected,
            new In(
                "[Id]",
                new ListOf<int>(
                    1, 2, 3, 4, 5
                )
            ).Raw()
        );
    }
}