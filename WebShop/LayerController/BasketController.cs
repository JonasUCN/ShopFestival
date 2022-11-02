using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace LayerController
{
    public class BasketController
    {
        private Basket basket;
        public BasketController()
        {
            basket = new Basket();
        }
        public void addProductToBasket(Product product) { basket.addProduct(product); }

        public Basket getBasket() { return basket; }
    }
}
