using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.LogicControllers;
using WebShop.Models;
using WebShop.ServiceLayer;

namespace WebShop.Controllers;
/// <summary>
/// This controller is responsible for handling requests related to the home page of the web shop.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IProductLogicController _ProductLogicController;
    public HomeController(ILogger<HomeController> logger, IConfiguration inConfiguration)
    {
        _logger = logger;
        _ProductLogicController = new ProductLogicController(inConfiguration);
    }

    /// <summary>
    /// This action method displays the homepage of the webshop.
    /// </summary>
    /// <returns>The index view with a list of products.</returns>
    public IActionResult Index()
    {
        List<Product> products = _ProductLogicController.GetProductsFromService();
        return View(products);
    }

    /// <summary>
    /// This action method displays the privacy policy of the webshop.
    /// </summary>
    /// <returns>The privacy view.</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// This action method displays an error page with the request ID of the error.
    /// </summary>
    /// <param name="model">The view model containing the request ID of the error.</param>
    /// <returns>The error view.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}