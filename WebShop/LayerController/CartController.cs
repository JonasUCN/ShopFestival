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

        public void addProductToCart(Product product)
        {if(product.Stock < 1) { return; }
            cart.addProduct(product);
        }

        public Cart getCart() { return cart; }
    }
}
