using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using DesktopApp.ModelLayer;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace DesktopApp.ServiceLayer
{
    /// <summary>
    /// The `ProductAccess` class provides methods for accessing product data in the database.
    /// </summary>
    public class ProductAccess : IProductAccess
    {
        /// <summary>
        /// The `TokenAccess` instance used to retrieve tokens for authorization.
        /// </summary>
        TokenAccess TokenAccess;

        /// <summary>
        /// Constructs a new `ProductAccess` instance.
        /// </summary>
        /// <param name="configuration">The application configuration to use.</param>
        public ProductAccess(IConfiguration configuration)
        {
            TokenAccess = new TokenAccess(configuration);
        }

        /// <summary>
        /// The `RestClient` instance used to make HTTP requests.
        /// </summary>
        RestClient restClient = new RestClient("https://localhost:5001");
    


        /// <summary>
        /// Inserts a new product into the database.
        /// </summary>
        /// <param name="product">The product to insert.</param>
        /// <returns>True if the product was successfully inserted, false otherwise.</returns>
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
        /// <summary>
        /// Retrieves a product from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, or null if no such product exists.</returns>
        public Product GetProductByID(int id)
        {
            var request = new RestRequest($"api/Product/Products/{id}");
            request.AddHeader("Authorization", $"Bearer {TokenAccess.GetToken()}");
            var response = restClient.Get(request);
            
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;

        }
        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products in the database.</returns>
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
