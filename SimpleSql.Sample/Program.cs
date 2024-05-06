using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new In("Name", new StringsOf("0316", "0317", "0318", "0319")).Raw());
            var sql = new Select(
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
                            "Balance", ">", new SqlDecimalOf(10.0m)
                        )
                    ),
                    new And(
                        new In("LastName", new StringsOf("Ivanov", "Petrov", "Ivaschenko"))
                    )
                )
            ).Raw();
            
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}