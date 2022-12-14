using DesktopApp.ModelLayer;
using DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Desktop
{
    public class TestProductAccess
    {
        Microsoft.Extensions.Configuration.IConfiguration configuration;

        
        //Empty Product object IMPORTANT service needs to be running
        [Fact]
        public void InsertProduct_FailWithEmptyObject()
        {
            // Arrange
            bool expected = false;

            Product product = new Product() { };
            ProductAccess productAccess = new ProductAccess(configuration);
            //Act
            bool result = productAccess.InsertProduct(product);

            // assert
            Assert.Equal(expected, result);
        }

        // Product object With ID should not be Allowed to be persisted IMPORTANT service needs to be running
        [Fact]
        public void InsertProduct_FailWithIdPropoertyOnProductObject()
        {
            // Arrange
            bool expected = false;
            decimal Price = 22.22M;
            Product product = new Product() { id = 3, Brand = "Addias", Price = Price, ProductDesc = "Festivals Sko", Stock = 50, Title = "Festivals sko" };
            ProductAccess productAccess = new ProductAccess(configuration);
            //Act
            bool result = productAccess.InsertProduct(product);

            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void GetProductByID_ProductDoesNotexist()
        {
            //arrange
            ProductAccess productAccess = new ProductAccess(configuration);
            //act

            //assert
            Assert.Throws<HttpRequestException>(() => productAccess.GetProductByID(100000000));

        }
    }
}