using Bogus;
using Microsoft.Data.SqlClient;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using SqlObjects.SqlServer;

namespace SqlObjects.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var conn = new SqlConnection("Server=localhost;Database=Testing;Trusted_Connection=true;TrustServerCertificate=True");

            await conn.OpenAsync();

            IFetch fetch = new Fetch(conn);

            var productQuery = new Select(
                new Strings(
                    "[Id]",
                    "[CreatedAt]",
                    "[Name]",
                    "[Cost]"
                ),
                "[Products]"
            );

            var customerQuery = new Select(
                new Strings(
                    "[Id]",
                    "[CreatedAt]",
                    "[FirstName]",
                    "[LastName]"
                ),
                "[Customers]"
            );

            var products = fetch.Rows(productQuery);
            var customers = fetch.Rows(customerQuery);

            //var txn = new Txn<bool>.ReadCommitted(conn);

            //txn.Invoke(() =>
            //{
            //    for (int i = 0; i < 300; i++)
            //    {
            //        var faker = new Faker();
            //        var fname = faker.Person.FirstName;
            //        var lname = faker.Person.LastName;

            //        var statement = new Statement(conn, new Insert(
            //                "[Customers]",
            //                new Record(
            //                    new SqlParam("[FirstName]", fname),
            //                    new SqlParam("[LastName]", lname)
            //                )
            //            )
            //        );

            //        statement.Exec();
            //    }

            //    return true;
            //});

            await conn.CloseAsync();
            Console.ReadKey();
        }
    }
}