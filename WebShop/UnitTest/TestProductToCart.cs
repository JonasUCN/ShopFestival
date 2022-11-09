using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Controllers;

namespace UnitTest
{
    public class TestProductToCart
    {
        [Fact] 
        public void testAddProductToCart()
        {
            //Arrange
            string url = "https://localhost:5001/api/Product/Products/3";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            //Act
            productController.ProductView(product);
            //Assert
            Assert.Equal(3, cartController.getCart().GetProducts()[0].id);
        }

        [Fact]
        public void testAddProductZeroStock()
        {
            //Arrange
            string url = "https://localhost:5001/api/Product/Products/12";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            //Act
            productController.ProductView(product);
            //Assert
            Assert.Equal(12, cartController.getCart().GetProducts()[0].id);
            //Expected result is failure.
        }
    }
}
