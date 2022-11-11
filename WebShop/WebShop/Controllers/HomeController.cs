﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;
using ModelLayer;
using Database_Service.LogicController;
using Newtonsoft.Json;
using RestSharp;
using LayerController;

namespace WebShop.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
