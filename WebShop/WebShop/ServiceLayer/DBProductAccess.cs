using System;
using System.Security.Cryptography.X509Certificates;
using Database_Service;
using Database_Service.DataAccess;
using ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using WebShop.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class DBProductAccess : IDBProductAccess
	{
        public DBProductAccess(IConfiguration inConfiguration)
        {

        }

        public Product GetProductFromAPIByID(int id)
        {
            string url = "https://localhost:5001/api/Product/Products/" + id;
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;
        }

        public RestResponse RemoveStockByID(int id)
		{
            string url = "https://localhost:5001/api/Product/RemoveStock/" + id;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());
            return response;
        }

        public List<Product> getAllProductsFromAPI()
        {
            List<Product>? products = new List<Product>();
            string url = "https://localhost:5001/api/Product/Products/";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }
    }
}

