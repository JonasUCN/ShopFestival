using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WebShop.Models;
using Newtonsoft.Json;
using RestSharp;
using WebShop.ServiceLayer;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace WebShop.ServiceLayer
{
    public class DBProductAccess : IDBProductAccess
    {
        //public static string GetToken()
        //{
        //    string url = "https://localhost:5001/jwt";
        //    var client = new RestClient(url);
        //    var request = new RestRequest();
        //    request.AddHeader("Authorization", $"Bearer {ServiceToken.GetToken()}");
        //    var response = client.Get(new RestRequest());

        //    string responseToken = response.Content;
        //    string FinalToken = responseToken.Replace("\"", "");

        //    return FinalToken;
        //}

        public DBProductAccess(IConfiguration inConfiguration)
        {

        }

        public Product GetProductFromAPIByID(int id)
        {
            string url = "https://localhost:5001/api/Product/Products/" + id;
            var client = new RestClient(url);

            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenDefaultUser()}");

            var response = client.Get(request);
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;
        }

        public RestResponse RemoveStockByID(int id)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + id;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenDefaultUser()}");

            var response = client.Post(request);
            return response;
        }

        public List<Product> getAllProductsFromAPI()
        {
            List<Product>? products = new List<Product>();
            string url = "https://localhost:5001/api/Product/Products/";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenDefaultUser()}");

            var response = client.Get(request);
            products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }
    }
}