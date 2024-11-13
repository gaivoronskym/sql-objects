using System.Data;
using Microsoft.Data.SqlClient;

namespace SqlObjects.SqlServer;

public sealed class Fetch : FetchEnvelope
{
    public Fetch(SqlConnection conn)
        : base(
            query => new SqlCommand(
                query.Raw(),
                conn
            )
        )
    {
    }
}