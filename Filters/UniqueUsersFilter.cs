using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebApplication6.Filters
{
    public class UniqueUserFilter : ActionFilterAttribute
    {
        private static readonly HashSet<string> uniqueUserSet = new HashSet<string>();
        private static int userCounter = 0;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ipAddress = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();

            // Проверяем, был ли уже этот пользователь записан
            if (!uniqueUserSet.Contains(ipAddress))
            {
                // Если пользователь уникальный, добавляем его в множество, увеличиваем счетчик и записываем в файл
                uniqueUserSet.Add(ipAddress);
                userCounter++;

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string logMessage = $"{timestamp} - Unique user with IP Address '{ipAddress}' accessed the application. Total unique users: {userCounter}";

                LogToFile(logMessage);
            }

            base.OnActionExecuting(filterContext);
        }

        private void LogToFile(string message)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userLog.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
