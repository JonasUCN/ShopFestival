using Microsoft.AspNetCore.Mvc;
using Database_Service.DataAccess;
using Database_Service.Controllers;
using Database_Service.LogicController;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
<<<<<<< Updated upstream
        LogicProductController _ProductController;
        public ProductController(LogicProductController productController, List<Product> products)
        {
            _ProductController = new LogicProductController();
=======
        private CartController _CartController = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductView() //TODO Make it to take a para as int id to custom take what product to display
        {

            string url = "https://localhost:5001/api/Product/Products/3";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);

            return View(product);
>>>>>>> Stashed changes
        }

        //private readonly List<Product> products = _ProductController.GetAllProducts();

        //Test push

        public IActionResult Index()
        {
            return View();
        }
    }
}
