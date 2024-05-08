using System.Data;
using SimpleSql.Common;
using SimpleSql.Sample.Interfaces;

namespace SimpleSql.Sample;

public class DbContractor : IContractor
{
    private readonly IDbConnection _connection;
    private readonly long _id;

    public DbContractor(IDbConnection connection, long id)
    {
        _connection = connection;
        _id = id;
    }

    public long Id()
    {
        return _id;
    }

    public string Name()
    {
        var row = new Fetch(
            _connection,
            new Select(
                "[Contractors]",
                new SqlFields("[Name]"),
                new Queries(
                    new Where(
                        new Condition("[Id]", _id)
                    )
                )
            )
        ).Rows().First();

        return row.String("Name");
    }
}