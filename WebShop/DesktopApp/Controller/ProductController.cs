using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Database_Service.DataAccess;
using Model;

namespace DesktopApp.Controller
{
    private Product Product;
    public class ProductController : ProductControllerIF
    {
        public ProductController() 
        {
            ProductController = new ProductController;
        }

        public void createProduct()
        {
            Product product = new Product();
        }

        public List<Product> createProduct(decimal price, int stock, string productDesc, string brand, string title)
        {
            List <Product> = null;
            try
            {
                Product product = new Product(decimal price, int stock, string productDesc, string brand, string title);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
