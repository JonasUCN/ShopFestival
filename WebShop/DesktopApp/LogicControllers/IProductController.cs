using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.LogicControllers
{
    internal interface IProductController
    {
        bool createProduct(decimal price, int stock, string productDesc, string brand, string title);
        List<Product> GetProducts();
    }
}
