using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ModelLayer;

using Newtonsoft.Json;
using System.Diagnostics;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace DesktopApp.DataAccess
{
    public class ProductAccess : IProductAccess
    {
        TokenAccess TokenAccess;

        public ProductAccess(IConfiguration configuration)
        {
           TokenAccess = new TokenAccess(configuration);

        }
        
        RestClient restClient = new RestClient("https://localhost:5001");
        public bool InsertProduct(Product product)
        {
            bool success = false;
            if (product.id == null)
            {
                string json = JsonConvert.SerializeObject(product);
                var request = new RestRequest($"api/Product/Create", Method.Post);
                request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
                request.AddJsonBody(json);
                var response = restClient.Execute(request);

                success = response.IsSuccessful;

            }
            return success;
        }

        public Product GetProductByID(int id)
        {
            var request = new RestRequest($"api/Product/Products/{id}");
            request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
            var response = restClient.Get(request);
            
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;

        }

        public List<Product> GetAllProducts()
        {
            var request = new RestRequest("api/Product/Products");
            request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
            var response = restClient.Get(request);
            List<Product> products =  JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }
    }
}
