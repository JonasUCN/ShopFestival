
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Newtonsoft.Json.Schema;
using System.Text.Json.Nodes;

namespace DesktopApp.DataAccess
{
    public class SaleOrderAccess : ISaleOrderAccess
    {
        RestClient restClient = new RestClient("https://localhost:5001");

        public List<SaleOrder> GetAllSaleOrder()
        {
            var request = new RestRequest("api/SaleOrder/SaleOrders");
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
