using System.Data.SqlClient;
using SimpleSql.Common;
using SimpleSql.Servers.SqlServer;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=localhost;Database=ObjectsDb;User Id=polybase-user; Password=12345;";
            var connection = new SqlConnection(
                connectionString
            );
            connection.Open();

            try
            {
                // var rows = new SyncFetch(
                //     connection,
                //     new Select(
                //         "[Items] _item",
                //         new Queries(
                //             new RawSql("_item.[Id]"),
                //             new RawSql("_item.[Name]"),
                //             new SumOf("ISNULL(_inventory.[Quantity], 0)", "[InStockQuantity]")
                //         ),
                //         new Queries(
                //             new LeftJoin(
                //                 "[Inventories] _inventory",
                //                 "_item.[Id]",
                //                 "_inventory.[ItemId]",
                //                 new And(
                //                     new Condition("_inventory.[Shipped]", false)
                //                 )
                //             ),
                //             new GroupBy("_item.[Id]", "_item.[Name]")
                //         )
                //     )
                // ).Rows();

                new Txn.ReadUnCommitted(
                    connection,
                    () =>
                    {
                        // var id = new Execution<long>(
                        //     connection,
                        //     new Insert(
                        //         "[Contractors]",
                        //         new SqlParamsOf(
                        //             new SqlParam("[Name]", "Driver")
                        //         ),
                        //         new ScopeIdentity()
                        //     )
                        // ).Invoke();

                        new Execution<int>(
                            connection,
                            new Update(
                                "[Contractors]",
                                new SqlParamsOf(
                                    new SqlParam("[Name]", "Mr. Driver")
                                ),
                                new Queries(
                                    new Where(
                                        new Condition("[Id]", 2)
                                    )
                                )
                            )
                        ).Invoke();
                    }
                ).Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            connection.Close();
            // new Select(
            //     "Customers",
            //     new SqlFields(
            //         "Id",
            //         "FirstName",
            //         "LastName",
            //         "Balance"
            //     ),
            //     new Queries(
            //         new Where(
            //             new Condition(
            //                 "Balance", ">", 10m
            //             )
            //         ),
            //         new And(
            //             new In("LastName", new StringsOf("Ivanov", "Petrov", "Ivaschenko"))
            //         )
            //     )
            // ).Raw();
            //
            // new Insert(
            //     "Items",
            //     new SqlParamsOf(
            //         new SqlParam("Name", "0316"),
            //         new SqlParam("Description", new SqlNull()),
            //         new SqlParam("Cost", 9.99m)
            //     )
            // ).Raw();

            // var sql = new Delete(
            //     "Categories",
            //     new Where(new Condition("Id", new SqlIntOf(5)))
            // ).Raw();

            // new Select(
            //     "Items item",
            //     new SqlFields(
            //         "item.Id", "item.Name", "itemSetting.DontSync"
            //     ),
            //     new Queries(
            //         new InnerJoin("ItemSettings itemSetting", "itemSetting.ItemId", "item.Id"),
            //         new OrderByAsc("item.Id")
            //     )
            // ).Raw();
            //
            // new Update(
            //     "Items",
            //     new SqlParamsOf(
            //         new SqlParam("Cost", 7.99m)
            //     ),
            //     new Where(
            //         new Condition("Id", 1)
            //     )
            // ).Raw();
            
            //Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}