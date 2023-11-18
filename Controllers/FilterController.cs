using Microsoft.AspNetCore.Mvc;
using WebApplication6.Filters;

namespace WebApplication6.Controllers
{
    [LogActionFilter]
    [UniqueUserFilter]
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return Content("Index.");
        }
        public IActionResult Privacy() {
            return Content("Privacy.");
        }
    }
}
