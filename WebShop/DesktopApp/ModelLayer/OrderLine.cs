using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    /// <summary>
    /// The `OrderLine` class represents a single line in an order, consisting of a product and a quantity.
    /// </summary>
    public class OrderLine
    {
        // The product in this order line
        public Product Product { get; set; }

        // The quantity of the product in this order line
        public int Quantity { get; set; }

        // The subtotal for this order line, calculated by multiplying the product's price by the quantity
        public decimal SubTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}