namespace WebApplication1.Services
{
    public class TimeService
    {
        public string GetTime()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                return "День";
            }
            else if (currentTime.Hour >= 18 && currentTime.Hour < 24)
            {
                return "Вечір";
            }
            else if (currentTime.Hour >= 0 && currentTime.Hour < 6)
            {
                return "Ніч";
            }
            else
            {
                return "Ранок";
            }
        }
    }
}
