using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Model;
using Database_Service.DataAccess;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DesktopApp.DataAccess
{
    public class ProductAccess
    {

        RestClient restClient = new RestClient("https://localhost:5001");

        public void InsertProduct()
        {
            // Lav mulighed for at oprette et product på Service
        }
        
        public Product GetProductByID(int id)
        {
            var request = new RestRequest($"api/Product/Products/{id}");
            var response = restClient.Get(request);

            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;
            
        }




    }
}
