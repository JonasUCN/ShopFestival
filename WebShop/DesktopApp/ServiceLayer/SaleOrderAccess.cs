using DesktopApp.ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;

namespace DesktopApp.ServiceLayer
{
    /// <summary>
    /// The `SaleOrderAccess` class provides methods for accessing sale order data in the database.
    /// </summary>
    public class SaleOrderAccess : ISaleOrderAccess
    {
        /// <summary>
        /// The `TokenAccess` instance used to retrieve tokens for authorization.
        /// </summary>
        TokenAccess TokenAccess;

        /// <summary>
        /// Constructs a new `SaleOrderAccess` instance.
        /// </summary>
        /// <param name="configuration">The application configuration to use.</param>
        public SaleOrderAccess(IConfiguration configuration)
        {
            TokenAccess = new TokenAccess(configuration);
        }


        /// <summary>
        /// The `RestClient` instance used to make HTTP requests.
        /// </summary>
        RestClient restClient = new RestClient("https://localhost:5001");

        /// <summary>
        /// Gets a list of all sale orders in the database.
        /// </summary>
        /// <returns>A list of all sale orders in the database.</returns>
        public List<SaleOrder> GetAllSaleOrder()
        {
            RestClient restClient = new RestClient("https://localhost:5001");
            var request = new RestRequest("api/SaleOrder/SaleOrders");
            request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
            var response = restClient.Get(request);
            
            List<SaleOrder> saleOrders = ConvertJSONToListOfSaleOrders(response.Content);
            return saleOrders;
        }

        /// <summary>
        /// Converts a JSON string containing sale order data into a list of SaleOrder objects.
        /// </summary>
        /// <param name="content">The JSON string to convert.</param>
        /// <returns>A list of SaleOrder objects representing the data in the JSON string.</returns>
        public List<SaleOrder> ConvertJSONToListOfSaleOrders(string content)
        {
            
            return JsonConvert.DeserializeObject<List<SaleOrder>>(content);
        }

       
    }
}
