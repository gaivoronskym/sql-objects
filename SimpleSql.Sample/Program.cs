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
                var contractors = new ConstContractors(connection).List();

                foreach (var contractor in contractors)
                {
                    Console.WriteLine(contractor.Name());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            connection.Close();
            
            Console.ReadKey();
        }
    }
}