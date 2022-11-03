﻿using System;
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
        {
            cart.addItemToCart(product);
        }

        public void removeProductFromCart(Product product) { cart.removeItemFromCart(product); }

        public Cart getCart() { return cart; }
    }
}
