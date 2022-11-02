using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;
using ModelLayer;
using Database_Service.LogicController;
using Newtonsoft.Json;
using RestSharp;
using LayerController;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BasketController _basketController = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductView() //TODO Make it to take a para as int id to custom take what product to display
        {
            BasketController basketController = new BasketController();

            string url = "https://localhost:5001/api/Product/Products/3";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);

            return View(product);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            _basketController.addProductToBasket(_Product);
            return View(_Product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}