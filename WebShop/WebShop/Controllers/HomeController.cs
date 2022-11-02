using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;
using Model;
using Database_Service.LogicController;
using Newtonsoft.Json;
using RestSharp;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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

        public IActionResult ProductView()
        {
            string url = "https://localhost:5001/api/Product/Products/1";

            var client = new RestClient(url);

            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            ViewData["Product"] = product;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}