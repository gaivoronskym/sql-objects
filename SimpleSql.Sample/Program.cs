using Yaapii.Atoms.Text;

namespace SimpleSql.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sql = new Select(
                "Customers",
                new Strings(
                    "Id",
                    "FirstName",
                    "LastName",
                    "Balance"
                ),
                new Queries(
                    new Where(
                        new Condition(
                            "Balance", ">", new TextOf("10.000")
                        )
                    ),
                    new And(
                        new Brackets(
                            new Or(
                                new Condition(
                                    "LastName", new TextOf("'Ivanov'")
                                )
                            ),
                            new Or(
                                new Condition(
                                    "LastName", new TextOf("'Petrov'")
                                )
                            ),
                            new Or(
                                new Condition(
                                    "LastName", new TextOf("'Dostoevskiy'")
                                )
                            )
                        )
                    )
                )
            ).Raw();
            
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}