using LayerController;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using WebShop.DBAccess;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private CartCon _CartController = new();
        private DBProductAccess dbpa = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductView() //TODO Make it to take a para as int id to custom take what product to display
        {
            Product pp = DBProductAccess.GetProductFromAPIByID(1);
            return View(pp);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            var response = DBProductAccess.RemoveStockByID(_Product.id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _CartController.addOrderLineToCart(new OrderLine { Product = _Product, Quantity = 1 }); //TODO Fix quantity to match the page to chose the quantity 
            }
            return View(_Product);
        }

        public CartCon GetCartController()
        {
            return _CartController;
        }
    }
}
