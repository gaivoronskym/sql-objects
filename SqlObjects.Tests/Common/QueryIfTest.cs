using SqlObjects;
using SqlObjects.Common;
using Yaapii.Atoms.Text;

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
            "FROM [Items];"
        ).AsString();

        Assert.Equal(
            expected,
            new QueryIf(
                true,
                new Select(
                    "[Items]",
                    new Strings(
                        "[Id]",
                        "[Name]"
                    )
                )
            ).Raw()
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
                    "[Items]",
                    new Strings(
                        "[Id]",
                        "[Name]"
                    )
                )
            ).Raw()
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
            "FROM [Items];"
        ).AsString();

        Assert.Equal(
            expected,
            new QueryIf(
                () => true,
                new Select(
                    "[Items]",
                    new Strings(
                        "[Id]",
                        "[Name]"
                    )
                )
            ).Raw()
        );
    }
}