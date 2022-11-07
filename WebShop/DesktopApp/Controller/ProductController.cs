using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using DesktopApp.DataAccess;
using ModelLayer;

namespace DesktopApp.Controller
{
    
    public class ProductController
    {
        private ProductAccess dataAccess = new ProductAccess();

        public bool createProduct(decimal price, int stock, string productDesc, string brand, string title)
        {
            bool success = false;

            try 
            { 
            
                if(price >= 0 && stock >= 0)
                {
                    Product product = new Product() { Price = price, Stock = stock, ProductDesc = productDesc, Brand = brand, Title = title };
                    dataAccess.InsertProduct(product);
                    success = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return success;
        }
    }
}
