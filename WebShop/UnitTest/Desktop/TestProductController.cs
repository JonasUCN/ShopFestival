using DesktopApp.LogicControllers;
using DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Desktop
{
    public class TestProductController
    {
        Microsoft.Extensions.Configuration.IConfiguration configuration;


        [Theory]
        //Arrange
        [InlineData(22, 23, "product b", "nike", "Sko", true)]
        [InlineData(22, -24, "product b", "nike", "Sko", false)]
        [InlineData(-22, 23, "product b", "nike", "Sko", false)]

        public void ControllerCreateProductTest(decimal price, int stock, string productDesc, string brand, string title, bool expected)
        {

            // Act
            ProductController productController = new ProductController(new ProductAccess(configuration));
            bool result = productController.createProduct(price, stock, productDesc, brand, title);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}