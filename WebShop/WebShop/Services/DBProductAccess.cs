using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Database_Service;
using ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using WebShop.Services;

namespace WebShop.DBAccess
{
    public class DBProductAccess
    {

        public static string GetToken()
        {
            string url = "https://localhost:5001/jwt";
            var client = new RestClient(url);

            var response = client.Get(new RestRequest());
            string responseToken = response.Content;
            string FinalToken = responseToken.Replace("\"", "");

            return FinalToken;
        }

        public static Product GetProductFromAPIByID(int id)
        {
            string url = "https://localhost:5001/api/Product/Products/" + id;
            var client = new RestClient(url);

            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetToken()}");

            var response = client.Get(request);
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;
        }

        public static RestResponse RemoveStockByID(int id)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + id;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetToken()}");

            var response = client.Post(request);
            return response;
        }

        public static List<Product> getAllProductsFromAPI()
        {
            List<Product>? products = new List<Product>();
            string url = "https://localhost:5001/api/Product/Products/";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetToken()}");

            var response = client.Get(request);
            products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }
    }
}

