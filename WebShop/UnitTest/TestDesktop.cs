using Model;
using System.Runtime.InteropServices;
using DesktopApp;
using DesktopApp.Controller;
using Database_Service.DataAccess;
using System.Diagnostics;
using DesktopApp.DataAccess;

namespace UnitTest
{
    public class TestDesktop
    {
        [Fact]
        public void CreatingProductTest()
        {
            Product compare = new Product();

            decimal Price = 22;
            int Stock = 22;
            string ProductDesc = "Product beskrivelse";
            string Brand = "Addias";
            string Title = "Festivals sko";

            compare.Price = Price;
            compare.Stock = Stock;
            compare.ProductDesc = ProductDesc;
            compare.Brand = Brand;
            compare.Title = Title;
           

            ProductController productController = new ProductController();

            Product Result = null;//productController.CreateProduct(Price,Stock,ProductDesc,Brand,Title);

            Assert.Equal(Result, compare);
        }

        [Fact]

        public void FindProductTest()
        {
            int id = 3;

            ProductAccess productAccess = new ProductAccess();
            Product result = productAccess.GetProductByID(id);

            Assert.NotNull(result); 

        }

    }
}