using System.Data.SqlClient;
using System.Diagnostics;
using SimpleSql.Common;
using SimpleSql.Sample.Schema;

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

            var dboItems = new DboItems("item");
            var sql = new LoggedQuery(
                new Select(
                    dboItems.TableName(),
                    new Columns(
                        dboItems.Id(),
                        dboItems.Name(),
                        dboItems.Cost(),
                        dboItems.Price()
                    ),
                    new Queries(
                        new Where(
                            new Condition(
                                dboItems.Id(),
                                5
                            )
                        )
                    )
                )
            ).Raw();
            
            /*var ids = new ListOf<long>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            
            var sql = new LoggedQuery(
                new QueryOf(
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
                )
            ).Raw();*/

            Debug.Print("------------------------------------------------------------");

            /*var dboItems = new DboItems();

            var insertSql = new LoggedQuery(
                new Insert(
                    dboItems.TableName(),
                    new RecordsOf(
                        new SqlParamsOf(
                            new SqlParam(
                                dboItems.Name(), "436346437347"
                            ),
                            new SqlParam(
                                dboItems.Cost(), 10.0m
                            )
                        ),
                        new SqlParamsOf(
                            new SqlParam(
                                dboItems.Name(), "4867343463464"
                            ),
                            new SqlParam(
                                dboItems.Cost(), 9.0m
                            )
                        )
                    ),
                    new ScopeIdentity()
                )
            ).Raw();*/
            
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