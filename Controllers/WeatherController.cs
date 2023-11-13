using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
