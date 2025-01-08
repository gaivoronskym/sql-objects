using SqlObjects.Common;
using Yaapii.Atoms.Enumerable;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Tests.Common;

public class QueryIfTest
{
    [Fact]
    public void TestIfConditionIsTrue()
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
            new QueryIf(
                true,
                new Select(
                    new ManyOf(
                        "[Id]",
                        "[Name]"
                    ),
                    "[Items]"
                )
            ).Sql()
        );
    }

    [Fact]
    public void TestIfConditionIsFalse()
    {
        string expected = new Joined(
            Environment.NewLine,
            "SELECT",
            "[Id], [Name]",
            "FROM [Items];"
        ).AsString();

        Assert.NotEqual(
            expected,
            new QueryIf(
                false,
                new Select(
                    new ManyOf(
                        "[Id]",
                        "[Name]"
                    ),
                    "[Items]"
                )
            ).Sql()
        );
    }

    [Fact]
    public void TestFuncCondition()
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
            new QueryIf(
                () => true,
                new Select(
                    new ManyOf(
                        "[Id]",
                        "[Name]"
                    ),
                    "[Items]"
                )
            ).Sql()
        );
    }
}