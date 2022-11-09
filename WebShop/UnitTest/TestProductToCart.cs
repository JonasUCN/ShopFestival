using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 50, Title = "Festivals sko" };

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
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 0, Title = "Festivals sko" };

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
