using Microsoft.AspNetCore.Mvc;
using Database_Service.DataAccess;
using Database_Service.Controllers;
using Database_Service.LogicController;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        LogicProductController _ProductController;
        public ProductController(LogicProductController productController, List<Product> products)
        {
            _ProductController = new LogicProductController();
        }

        //private readonly List<Product> products = _ProductController.GetAllProducts();

        public IActionResult Index()
        {
            return View();
        }
    }
}
