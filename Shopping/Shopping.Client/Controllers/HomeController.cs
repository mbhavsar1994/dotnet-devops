using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Interface;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {      
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {

        _logger.LogDebug("Product api is being called");

        var products = await _productService.GetProducts();

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

