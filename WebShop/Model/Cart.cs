﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Cart
    {
        private List<Product> products;

        public Cart()
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