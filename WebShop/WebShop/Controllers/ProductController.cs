using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.LogicControllers;
using WebShop.ServiceLayer;

namespace WebShop.Controllers
{
    /// <summary>
    /// The ProductController class is derived from the Controller class.
    /// It contains methods for handling product-related actions in the web application.
    /// </summary>
    public class ProductController : Controller
    {

        private ProductLogicController _ProductLogicController;
        private OrderLineLogicController OrderLineLogicController;

        /// <summary>
        /// Constructor for the ProductController that takes in an IConfiguration object
        /// </summary>
        /// <param name="inConfiguration">The IConfiguration object to use</param>
        public ProductController(IConfiguration inConfiguration)
        {
            OrderLineLogicController = new OrderLineLogicController(inConfiguration);
            _ProductLogicController = new ProductLogicController(inConfiguration);
        }

        /// <summary>
        /// The Index ActionResult for the ProductController
        /// </summary>
        /// <returns>A ViewResult object</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets a list of products from the ProductLogicController's GetProductsFromService method
        /// </summary>
        public IActionResult ProductsView()
        {
            List<Product> products = _ProductLogicController.GetProductsFromService();
            return View(products);
        }

        // <summary>
        /// Gets a single product from the ProductLogicController's GetProductFromServiceByID method
        /// </summary>
        public IActionResult ProductView(int id)
        {
            Product pp = _ProductLogicController.GetProductFromServiceByID(id);
            return View(pp);
        }

        /// <summary>
        /// This method receives an ID and uses it to retrieve a list of products.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A view of the retrieved products.</returns>
        [HttpPost]
        public IActionResult ProductsView(int id) 
        { 
            HttpContext http = HttpContext;
            List<Product> products = _ProductLogicController.AddProductToCart(id, http);
            return View(products);
        }

        /// <summary>
        /// This method receives a Product object as input and adds it to an order.
        /// </summary>
        /// <param name="_Product">The Product to add to the order.</param>
        /// <returns>A view of the updated product.</returns>
        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            HttpContext http = HttpContext;
            Product product = _ProductLogicController.addProductToOrder(_Product, http);
            return View(product);
        }
    }
}