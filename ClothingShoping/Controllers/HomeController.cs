using ClothingShoping.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClothingShoping.Services;
using ClothingShoping.Data;

namespace ClothingShoping.Controllers
{
    public class HomeController : Controller
    {
        IProductService productService;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            productService.GetListProductIncludeCategory();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0 ,Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}