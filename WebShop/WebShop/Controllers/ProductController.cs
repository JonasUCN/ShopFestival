using LayerController;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Newtonsoft.Json;
using RestSharp;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private CartCon _CartController = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductView() //TODO Make it to take a para as int id to custom take what product to display
        {

            Product product = getProductFromAPIByID(3);

            return View(product);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + _Product.id;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _CartController.addOrderLineToCart(new OrderLine { Product = _Product, Quantity = 1}); //TODO Fix quantity to match the page to chose the quantity 
            }
            return View(_Product);
        }

        public LayerController.CartCon GetCartController()
        {
            return _CartController;
        }

        private Product getProductFromAPIByID(int id)
        {
            string url = "https://localhost:5001/api/Product/Products/" + id;
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);

            return product;
        }
    }
}
