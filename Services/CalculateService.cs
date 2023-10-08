using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services
{
    public class CalculateService
    {

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Дiльник не може бути нулем.");
            }
            return a / b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }
}
