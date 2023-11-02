using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Створення колекції з даними Product
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 10.99m, CreatedDate = DateTime.Now },
                new Product { ID = 2, Name = "Product 2", Price = 19.99m, CreatedDate = DateTime.Now },
                new Product { ID = 3, Name = "Product 3", Price = 7.99m, CreatedDate = DateTime.Now },
            };

            // Передача колекції як моделі до представлення
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
}