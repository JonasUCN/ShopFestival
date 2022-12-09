using WebShop.Models;
using Newtonsoft.Json;
using RestSharp;

namespace WebShop.Services
{
    public class DBCustomerAccess
    {
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
