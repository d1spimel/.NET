using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication1
{
    public class ErrorLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Логування помилки у файл errors.log
                LogErrorToFile(ex);
                throw; // Продовжити обробку помилки
            }
        }

        private void LogErrorToFile(Exception ex)
        {
            string logFilePath = "errors.log";

            using (var writer = new StreamWriter(logFilePath, append: true))
            {
                writer.WriteLine($"[{DateTime.Now}] {ex.Message}");
                writer.WriteLine(ex.StackTrace);
                writer.WriteLine(new string('-', 40));
            }
        }
    }
}
public static class ErrorLogMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorLogMiddleware>();
    }
}