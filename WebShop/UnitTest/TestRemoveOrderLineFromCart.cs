using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Controllers;

namespace UnitTest
{
    public class TestRemoveOrderLineFromCart
    {
        [Fact]
        public void TestRemoveOrderLineFromCartObject()
        {
            //Arrange
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 5, Title = "Festivals sko", id = 12 };
            OrderLine orderLine = new OrderLine { product = product, quantity = 1 };
            ProductController productController = new();
            CartController cartController = productController.GetCartController();
            cartController.addOrderLineToCart(orderLine);
            //Act
            cartController.removeProductFromCart(orderLine);
            //Assert
            Assert.Equal(0, cartController.getCart().GetOrderLines().Count);
        }
    }
}
