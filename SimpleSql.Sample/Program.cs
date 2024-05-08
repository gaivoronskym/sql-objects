using SimpleSql.Common;
using SimpleSql.Servers.SqlServer;
using SimpleSql.Types;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Select(
                "Customers",
                new SqlFields(
                    "Id",
                    "FirstName",
                    "LastName",
                    "Balance"
                ),
                new Queries(
                    new Where(
                        new Condition(
                            "Balance", ">", 10m
                        )
                    ),
                    new And(
                        new In("LastName", new StringsOf("Ivanov", "Petrov", "Ivaschenko"))
                    )
                )
            ).Raw();

            new Insert(
                "Items",
                new SqlParamsOf(
                    new SqlParam("Name", "0316"),
                    new SqlParam("Description", new SqlNull()),
                    new SqlParam("Cost", 9.99m)
                )
            ).Raw();

            // var sql = new Delete(
            //     "Categories",
            //     new Where(new Condition("Id", new SqlIntOf(5)))
            // ).Raw();

            new Select(
                "Items item",
                new SqlFields(
                    "item.Id", "item.Name", "itemSetting.DontSync"
                ),
                new Queries(
                    new InnerJoin("ItemSettings itemSetting", "itemSetting.ItemId", "item.Id"),
                    new OrderByAsc("item.Id")
                )
            ).Raw();

            new Update(
                "Items",
                new SqlParamsOf(
                    new SqlParam("Cost", 7.99m)
                ),
                new Where(
                    new Condition("Id", 1)
                )
            ).Raw();
            
            //Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}