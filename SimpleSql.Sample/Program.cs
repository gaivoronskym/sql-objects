using SimpleSql.Servers.SqlServer;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var sql = new Select(
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
            //                 "Balance", ">", new SqlDecimalOf(10.0m)
            //             )
            //         ),
            //         new And(
            //             new In("LastName", new StringsOf("Ivanov", "Petrov", "Ivaschenko"))
            //         )
            //     )
            // ).Raw();

            // var sql = new Insert(
            //     "Items",
            //     new SqlParamsOf(
            //         new SqlParam("Name", new SqlStringOf("0316")),
            //         new SqlParam("Description", new SqlNull()),
            //         new SqlParam("Cost", new SqlDecimalOf(9.99m))
            //     )
            // ).Raw();

            // var sql = new Delete(
            //     "Categories",
            //     new Where(new Condition("Id", new SqlIntOf(5)))
            // ).Raw();

            var sql = new Select(
                "Items item",
                new SqlFields(
                    "item.Id", "item.Name", "itemSettings.DontSync"
                ),
                new Queries(
                    new InnerJoin("ItemSettings itemSetting", "itemSetting.ItemId", "item.Id"),
                    new OrderByAsc("item.Id")
                )
            ).Raw();
            
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}