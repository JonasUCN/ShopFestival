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
    public class SaleOrderAccess : ISaleOrderAccess
    {

        TokenAccess TokenAccess;
        public SaleOrderAccess(IConfiguration configuration)
        {
            TokenAccess = new TokenAccess(configuration);

        }


        public RestClient restClient = new RestClient("https://localhost:5001");
           
        public List<SaleOrder> GetAllSaleOrder()
        {
            RestClient restClient = new RestClient("https://localhost:5001");
            var request = new RestRequest("api/SaleOrder/SaleOrders");
            request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
            var response = restClient.Get(request);
            
            List<SaleOrder> saleOrders = ConvertJSONToListOfSaleOrders(response.Content);
            return saleOrders;
        }

        public  List<SaleOrder> ConvertJSONToListOfSaleOrders(string content)
        {
            
            return JsonConvert.DeserializeObject<List<SaleOrder>>(content);
        }

       
    }
}
