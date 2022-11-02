using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Basket
    {
        private List<Product> products;

        public Basket()
        {
            products = new List<Product>();
        }

        public void addProduct(Product product)
        {
            if (product != null) { products.Add(product); }
        }

        public List<Product> GetProducts() { return products; }
    }
}
