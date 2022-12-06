using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}
