using SqlObjects.Common;
using SqlObjects.Sample.Schema;
using Yaapii.Atoms.List;

namespace SqlObjects.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var dboItems = new DboItems("item");
            var sql = new LoggingQuery(
                new Select(
                    dboItems.TableName(),
                    new ListOf<string>(
                        dboItems.Id(),
                        dboItems.Name(),
                        dboItems.Cost(),
                        dboItems.Price()
                    ),
                    new Where(
                        new Expression(
                            dboItems.Id(),
                            5
                        )
                    )
                )
            ).Raw();
            
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}