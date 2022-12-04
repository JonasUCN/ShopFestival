using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using WebShop.LogicControllers;
using WebShop.ServiceLayer;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {

        private ProductLogicController _ProductLogicController;
        private OrderLineLogicController OrderLineLogicController;

        public ProductController(IConfiguration inConfiguration)
        {
            OrderLineLogicController = new OrderLineLogicController(inConfiguration);
            _ProductLogicController = new ProductLogicController(inConfiguration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsView()
        {
            List<Product> products = _ProductLogicController.GetProductsFromService();
            return View(products);
        }

        public IActionResult ProductView(int id)
        {
            Product pp = _ProductLogicController.GetProductFromServiceByID(id);
            return View(pp);
        }

        [HttpPost]
        public IActionResult ProductsView(int id) //TODO Flyttes ned i LogicControllers. Kaldes her.
        {
            HttpContext http = HttpContext;
            List<Product> products = _ProductLogicController.AddProductToCart(id, http);
            return View(products);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            HttpContext http = HttpContext;
            Product product = _ProductLogicController.addProductToOrder(_Product, http);
            return View(product);
        }
    }
}
