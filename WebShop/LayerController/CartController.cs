using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Database_Service.Controllers;

namespace LayerController
{
    public class CartController
    {
        private Cart cart;

        public CartController()
        {
            cart = new Cart();
        }

        public void addOrderLineToCart(OrderLine orderLine)
        {
            if(orderLine.quantity > orderLine.product.Stock) {
                return;
            }
            cart.addOrderLine(orderLine);
        }

        public void removeProductFromCart(OrderLine orderLine)
        {
            cart.removeOrderLine(orderLine);
        }

        public Cart getCart() { return cart; }
    }
}
