using Database_Service.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Diagnostics;
using WebShop.LogicControllers;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IProductLogicController _ProductLogicController;
    public HomeController(ILogger<HomeController> logger, IConfiguration inConfiguration)
    {
        _logger = logger;
        _ProductLogicController = new ProductLogicController(inConfiguration);
    }
    public IActionResult Index()
    {
        List<Product> products = _ProductLogicController.GetProductsFromService();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}