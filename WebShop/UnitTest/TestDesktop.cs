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
            //Product compare = new Product();

            decimal Price = 22;
            int Stock = 22;
            string ProductDesc = "Product beskrivelse";
            string Brand = "Addias";
            string Title = "Festivals sko";

            //compare.Price = Price;
            //compare.Stock = Stock;
            //compare.ProductDesc = ProductDesc;
            //compare.Brand = Brand;
            //compare.Title = Title;


            ProductController productController = new ProductController();
            bool result = productController.createProduct(Price,Stock,ProductDesc,Brand,Title);
            Assert.True(result);
        }

        //[Fact]

        //public void FindProductTest()
        //{
        //    int id = 3;
        //    TestProductAccess productAccess = new TestProductAccess();
        //    Product result = productAccess.GetProductByID(id);
        //    Assert.NotNull(result); 

        //}

    }
}