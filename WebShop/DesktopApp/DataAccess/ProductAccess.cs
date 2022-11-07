﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ModelLayer;

using Newtonsoft.Json;
using System.Diagnostics;
using System.Data.Common;

namespace DesktopApp.DataAccess
{
    public class ProductAccess
    {

        RestClient restClient = new RestClient("https://localhost:5001");

        public bool InsertProduct(Product product)
        {
            bool success = false;
            if (product.id == null)
            {
                string json = JsonConvert.SerializeObject(product);
                var request = new RestRequest($"api/Product/Create", Method.Post);

                request.AddJsonBody(json);
                var response = restClient.Execute(request);

                success = response.IsSuccessful;

            }
            return success;
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
