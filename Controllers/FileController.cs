using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace AspNetMVC.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            byte[] fileBytes = Encoding.UTF8.GetBytes(content);

            string mimeType = "text/plain";

            return File(fileBytes, mimeType, fileName);
        }
    }
}

