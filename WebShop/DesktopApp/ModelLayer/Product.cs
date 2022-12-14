using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    // This is the Product class
    // It represents a product that can be sold, with various properties such as price and stock level
    public class Product
    {
        // The unique ID of the product
        public int id { get; set; }

        // The price of the product
        public decimal Price { get; set; }

        // The stock level of the product
        public int Stock { get; set; }

        // A description of the product
        public string ProductDesc { get; set; }

        // The brand of the product
        public string Brand { get; set; }

        // The title or name of the product
        public string Title { get; set; }
    }
}