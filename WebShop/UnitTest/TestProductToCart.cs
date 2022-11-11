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
        public void TestAddOrderLineToCart()
        {
            //Arrange
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 50, Title = "Festivals sko", id = 3 };
            OrderLine orderLine = new OrderLine { product = product, quantity = 1 };
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            //Act
            cartController.addOrderLineToCart(orderLine);
            //Assert
            Assert.Equal(3, cartController.getCart().GetOrderLines()[0].product.id);
        }

        [Fact]
        public void TestAddOrderLineZeroStock()
        {
            //Arrange
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 0, Title = "Festivals sko", id = 12 };
            OrderLine orderLine = new OrderLine { product = product, quantity = 1 };
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            //Act
            cartController.addOrderLineToCart(orderLine);
            //Assert
            Assert.Equal(12, cartController.getCart().GetOrderLines()[0].product.id);
            //Expected result is failure.
        }
        [Fact]
        public void TestDuplicateOrderLine()
        {
            //Arrange
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 100, Title = "Festivals sko", id = 12 };
            OrderLine orderLine = new OrderLine { product = product, quantity = 1 };
            OrderLine orderline2 = new OrderLine { product = product, quantity = 5 };
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            cartController.addOrderLineToCart(orderLine);
            //Act
            cartController.addOrderLineToCart(orderline2);
            //Assert
            Assert.Equal(6, cartController.getCart().GetOrderLines()[0].quantity);
            Assert.Single(cartController.getCart().GetOrderLines());
        }
    }
}
