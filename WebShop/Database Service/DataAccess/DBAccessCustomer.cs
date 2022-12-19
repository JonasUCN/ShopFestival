using Dapper;
using Database_Service.LogicController;
using Database_Service.Model;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// This class provides access to customer data stored in a database.
    /// </summary>
    public class DBAccessCustomer
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBAccessCustomer"/> class.
        /// </summary>
        public DBAccessCustomer()
        {
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;";
        }

        /// <summary>
        /// Gets a customer with the specified email address from the database.
        /// </summary>
        /// <param name="email">The email address of the customer to retrieve.</param>
        /// <returns>A <see cref="Customer"/> object with the customer data.</returns>
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

        /// <summary>
        /// Gets the city associated with the specified zip code from the database.
        /// </summary>
        /// <param name="zipcode">The zip code to look up.</param>
        /// <returns>A string containing the name of the city associated with the specified zip code.</returns>
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
