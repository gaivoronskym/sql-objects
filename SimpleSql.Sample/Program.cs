using System.Data.SqlClient;
using SimpleSql.Common;
using SimpleSql.Servers.SqlServer;
using Yaapii.Atoms.List;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = @"Server=localhost;Database=ObjectsDb;User Id=polybase-user; Password=12345;";
            var connection = new SqlConnection(
                connectionString
            );
            connection.Open();

            var ids = new ListOf<long>();

            var sql = new QueryOf(
                new DeclareOf("ids", "[dbo].[Ids]"),
                new InsertIf(
                    ids.Count > 0,
                    "@ids",
                    "[Id]",
                    ids
                ),
                new ProcedureOf(
                    "[SearchItems]",
                    new SqlParamsOf(
                        new SqlParam("ids", new RawSql("@ids")),
                        new SqlParam("name", "0316"),
                        new SqlParam("skip", 0),
                        new SqlParam("take", 500)
                    )
                )
            ).Raw();

            /*var sql = new Insert(
                "[Items]",
                new SqlParamsOf(
                    new SqlParam(
                        "[Name]", "1234545735687243"
                    )
                ),
                new ScopeIdentity()
            ).Raw(); */
            
            Console.Write(sql);
            
            // try
            // {
            //     var res = await new AsyncFetch(
            //         connection,
            //         new Select(
            //             "[Items]",
            //             new SqlFields(
            //                 "[Id]",
            //                 "[Name]"
            //             )
            //         )
            //     ).RowsAsync();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            // }
            
            connection.Close();
            
            Console.ReadKey();
        }
    }
}