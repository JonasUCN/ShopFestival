using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerController
{
    public interface ICartCon
    {
        public void addOrderLineToCart(OrderLine orderLine);

        public void removeProductFromCart(OrderLine orderLine);

        public Cart getCart();

        public bool addToExistingOrderLines(OrderLine orderLine);
    }
}
