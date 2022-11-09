using LayerController;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Newtonsoft.Json;
using RestSharp;

namespace WebShop.Controllers
{
    public class ProdukterController : Controller
    {
        private CartController _CartController = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProducterView() //TODO Make it to take a para as int id to custom take what product to display
        {

            string url = "https://localhost:5001/api/Product/Products/3";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product producter = JsonConvert.DeserializeObject<Product>(response.Content);

            return View(producter);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Produkter)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + _Produkter.id;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _CartController.addProductToCart(_Produkter);
            }
            return View(_Produkter);
        }

        public CartController GetCartController()
        {
            return _CartController;
        }
    }
}
