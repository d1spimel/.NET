using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication6.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string methodName = filterContext.ActionDescriptor.DisplayName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"{timestamp} - Action method '{methodName}' is called.";

            LogToFile(logMessage);

            base.OnActionExecuting(filterContext);
        }

        private void LogToFile(string message)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "actionLog.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
