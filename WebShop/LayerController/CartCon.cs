using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Database_Service.Controllers;

namespace LayerController
{
    public class CartCon : ICartCon
    {
        private Cart cart;

        public CartCon()
        {
            cart = new Cart();
        }

        public void addOrderLineToCart(OrderLine orderLine)
        {
            if (orderLine.Quantity > orderLine.Product.Stock || orderLine.Quantity == 0) {
                return;
            }

            if (orderLine.Product == null)
            {
                return;
            }

            if (addToExistingOrderLines(orderLine))
            {
                return;
            }

            cart.addOrderLine(orderLine);
        }

        public void removeProductFromCart(OrderLine orderLine)
        {
            cart.removeOrderLine(orderLine);
        }

        public Cart getCart() { return cart; }

        public bool addToExistingOrderLines(OrderLine orderLine)
        {
            bool existing = false;
            foreach (var item in cart.GetOrderLines())
            {
                if(orderLine.Product.id == item.Product.id)
                {
                    int sum = orderLine.Quantity + item.Quantity;
                    item.Quantity = sum;
                    existing = true;
                }

            }
            return existing;
        }
    }
}
