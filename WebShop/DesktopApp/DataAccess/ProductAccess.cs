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
using System.Data.Common;

namespace DesktopApp.DataAccess
{
    public class ProductAccess
    {

        RestClient restClient = new RestClient("https://localhost:5001");

        public bool InsertProduct(Product product)
        {
            string json = JsonConvert.SerializeObject(product);
            var request = new RestRequest($"api/Product/Create", Method.Post);
            
            request.AddJsonBody(json);
            var response = restClient.Execute(request);


            //bool success = Boolean.Parse(response.Content);
            return true;        
        }
        //var params = JsonConvert.SerializeObject{
        //    price = product.Price,
        //    stock = product.Stock,
        //    productDesc = product.ProductDesc,
        //    brand = product.Brand,
        //    title = product.Title,
        //};
        //request.AddObject (params);


        public Product GetProductByID(int id)
        {
            var request = new RestRequest($"api/Product/Products/{id}");
            var response = restClient.Get(request);

            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;

        }



    }
    
}
