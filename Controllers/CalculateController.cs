using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1
{
    public class CalculateController : Controller
    {
        private readonly CalculateService calculateService;

        public CalculateController(CalculateService calculateService)
        {
            this.calculateService = calculateService;
        }

        [HttpGet("divide")]
        public ActionResult Divide(double a, double b)
        {
            return Ok(calculateService.Divide(a, b));
        }
        

        [HttpGet("subtract")]
        public ActionResult Subtract(double a, double b)
        {
            return Ok(calculateService.Subtract(a, b));
        }

        [HttpGet("add")]
        public ActionResult Add(double a, double b)
        {
            return Ok(calculateService.Add(a, b));
        }
       
        [HttpGet("multiply")]
        public ActionResult Multiply(double a, double b)
        {
            return Ok(calculateService.Multiply(a, b));
        }
    }
}
