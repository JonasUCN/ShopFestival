using Microsoft.AspNetCore.Mvc;
using Database_Service.DataAccess;
using Database_Service.Controllers;
using Database_Service.LogicController;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        LogicProductController _ProductController = new();

        //public IActionResult List()
        //{
        //    List<Product> products = _ProductController.GetAllProducts();

        //    foreach (Product product in products)
        //    {
        //        products.Add(product);
        //    }
        //    return View(products);
        //}

        //https://learningprogramming.net/net/asp-net-mvc/pass-objects-list-from-controller-to-view-in-asp-net-mvc/

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();


            return View();
        }
    }
}
