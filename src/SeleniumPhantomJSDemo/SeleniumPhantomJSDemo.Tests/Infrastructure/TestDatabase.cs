using System.Configuration;
using System.Data.SqlClient;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure
{
    public class TestDatabase
    {
         public static void Cleanup()
         {
             using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ConnectionString))
             using (var command = connection.CreateCommand())
             {
                 connection.Open();
                 command.CommandText = "delete from Customers";
                 command.ExecuteNonQuery();
             }
         }
    }
}