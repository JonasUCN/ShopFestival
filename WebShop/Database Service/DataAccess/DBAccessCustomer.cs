using Dapper;
using Database_Service.LogicController;
using ModelLayer;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    public class DBAccessCustomer
    {
        private string connectionString;

        public DBAccessCustomer()
        {
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;";
        }

        public Customer GetCustomerByEmail(string email)
        {
            string sqlCustomer = "SELECT * FROM Customer WHERE email = @email";
            Customer c;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    c = connection.QuerySingle<Customer>(sqlCustomer, new { email = email });
                    c.City = GetCityFromZipCity(c.ZipCode);
                }
                catch (Exception)
                {
                    c = new Customer { Email = email };
                }
                return c;
            }
        }

        private string GetCityFromZipCity(string zipcode)
        {
            string city;

            string sqlCity = "SELECT city FROM ZipCity where zipcode = @zipcode";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                city = connection.QuerySingle<string>(sqlCity, new { zipcode = zipcode });
            }

            return city;
        }

    }
}
