using WebShop.Models;
using Newtonsoft.Json;
using RestSharp;

namespace WebShop.ServiceLayer
{
    /// <summary>
    /// A class for accessing customer data from the database using the API.
    /// </summary>
    public class DBCustomerAccess
    {
        /// <summary>
        /// Gets a customer from the database using the API by email.
        /// </summary>
        /// <param name="email">The email of the customer to retrieve.</param>
        /// <returns>A Customer object representing the customer with the given email.</returns>
        public static Customer GetCustomerFromAPIByEmail(string email)
        {
            string url = "https://localhost:5001/api/Customer/Customers/" + email;
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Console.WriteLine(response.Content);
            Customer c = JsonConvert.DeserializeObject<Customer>(response.Content);
            return c;
        }

    }
}
