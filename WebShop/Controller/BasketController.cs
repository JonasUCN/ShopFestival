using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class BasketController
    {
        private Basket basket;

        public BasketController()
        {
            basket = new();
        }

        public void addProductToBasket(Product product)
        {
            basket.addProduct(product);
        }
    }
}
