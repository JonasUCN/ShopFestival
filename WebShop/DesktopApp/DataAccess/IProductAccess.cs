using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DataAccess
{
    public interface IProductAccess
    {


        public bool InsertProduct(Product product);

        public Product GetProductByID(int id);

        public List<Product> GetAllProducts();
    }
}
