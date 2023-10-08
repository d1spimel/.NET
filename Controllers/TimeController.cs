using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1
{
    public class TimeController : Controller
    {
        private readonly TimeService timeService;
        public TimeController(TimeService timeService)
        {
            this.timeService = timeService;
        }
        [HttpGet("time")]
        public ActionResult GetTime()
        {
            string time = timeService.GetTime();
            return Ok($"Перiод дня: {time}.");
        }
    }
}
