using System.Data.SqlClient;
using ElegantSql.Sample.Schema;
using SqlObjects;
using SqlObjects.Common;

namespace ElegantSql.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new SqlConnection(
                @""
            );
            connection.Open();

            var dboItems = new DboItems("item");
            var sql = new LoggingQuery(
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
                            new ExpressionOf(
                                dboItems.Id(),
                                5
                            )
                        )
                    )
                )
            ).Raw();
            
            connection.Close();
            
            Console.ReadKey();
        }
    }
}