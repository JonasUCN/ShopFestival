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
    /// <summary>
    /// A class for accessing product data from the database using the API.
    /// </summary>
    public class DBProductAccess : IDBProductAccess
    {
        /// <summary>
        /// Creates a new instance of the DBProductAccess class.
        /// </summary>
        /// <param name="inConfiguration">The configuration to use for the API.</param>
        public DBProductAccess(IConfiguration inConfiguration)
        {

        }

        /// <summary>
        /// This method is used to retrieve a product from an API using the product's ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A product object.</returns>
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

        /// <summary>
        /// This method is used to remove stock for a product from an API using the product's ID.
        /// </summary>
        /// <param name="id">The ID of the product to remove stock for.</param>
        /// <returns>A response object from the API.</returns>
        public RestResponse RemoveStockByID(int id)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + id;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenDefaultUser()}");

            var response = client.Post(request);
            return response;
        }

        /// <summary>
        /// This method is used to retrieve all products from an API.
        /// </summary>
        /// <returns>A list of product objects.</returns>
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