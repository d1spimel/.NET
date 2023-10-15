using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    [Route("cookies")]
    public class CookiesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.CookieValue = Request.Cookies["cookie"];
            return View("Views\\cookies.cshtml");
        }

        [HttpPost("setCookies")]
        public IActionResult setCookies(string value, DateTime expirationDate)
        {
            // Збереження значення в Cookies із встановленням дати старіння.
            Response.Cookies.Append("MyCookie", value, new CookieOptions
            {
                Expires = expirationDate
            });

            return RedirectToAction("Index");
        }
    }
}