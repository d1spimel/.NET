using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ConsultationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ConsultationRequest request)
        {
            if (ModelState.IsValid)
            {
                // Обробка запиту і збереження даних
                // Можливо, редирект або інша логіка
                return RedirectToAction("Success");
            }

            return View(request);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
