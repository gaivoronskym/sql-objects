using System.Data;
using SimpleSql.Common;
using SimpleSql.Interfaces;
using SimpleSql.Sample.Interfaces;
using Yaapii.Atoms.Enumerable;

namespace SimpleSql.Sample;

public class DbContractors : IContractors
{
    private readonly IDbConnection _connection;

    public DbContractors(IDbConnection connection)
    {
        _connection = connection;
    }

    public IList<IContractor> List()
    {
        return new Yaapii.Atoms.List.Mapped<IRow, IContractor>(
            row => new DbContractor(
                _connection,
                row.Long("Id")
            ),
            new Fetch(
                _connection,
                new Select(
                    "[Contractors]",
                    new Columns(
                        "[Id]"
                    )
                )
            ).Rows()
        );
    }

    public IContractor Get(long id)
    {
        return new ItemAt<IContractor>(
            new Mapped<IRow, IContractor>(
                row => new DbContractor(
                    _connection,
                    row.Long("Id")
                ),
                new Fetch(
                    _connection,
                    new Select(
                        "[Contractors]",
                        new Columns(
                            "[Id]"
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