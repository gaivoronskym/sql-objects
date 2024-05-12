using System.Data;
using SimpleSql.Common;
using SimpleSql.Interfaces;
using SimpleSql.Sample.Interfaces;
using Yaapii.Atoms.Enumerable;

namespace SimpleSql.Sample;

public class ConstContractors(IDbConnection connection) : IContractors
{
    public IList<IContractor> List()
    {
        return new Yaapii.Atoms.List.Mapped<IRow, IContractor>(
            row => new ConstContractor(
                new DbContractor(
                    connection,
                    row.Long("Id")
                ),
                row.String("Name")
            ),
            new Fetch(
                connection,
                new Select(
                    "[Contractors]",
                    new Columns(
                        "[Id]",
                        "[Name]"
                    )
                )
            ).Rows()
        );
    }

    public IContractor Get(long id)
    {
        return new ItemAt<IContractor>(
            new Mapped<IRow, IContractor>(
                row => new ConstContractor(
                    new DbContractor(
                        connection,
                        row.Long("Id")
                    ),
                    row.String("Name")
                ),
                new Fetch(
                    connection,
                    new Select(
                        "[Contractors]",
                        new Columns(
                            "[Id]",
                            "[Name]"
                        ),
                        new Queries(
                            new Where(
                                new Condition("[Id]", id)
                            )
                        )
                    )
                ).Rows()
            )
        ).Value();
    }
}