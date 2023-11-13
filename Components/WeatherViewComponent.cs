using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AspNetMVC.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetMVC.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                string key = "94fdae26927ab52fdbf974d39ec976cd";
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={key}&units=metric";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic jsonFile = JsonConvert.DeserializeObject(content);

                    WeatherModel weather = new WeatherModel
                    {
                        City = jsonFile.name,
                        Temperature = jsonFile.main.temp,
                        Weather = jsonFile.weather[0].main,
                        WeatherDescription = jsonFile.weather[0].description,
                        Humidity = jsonFile.main.humidity,
                        WindSpeed = jsonFile.wind.speed,
                    };

                    return View("/Views/Weather/Weather.cshtml", weather);
                }
                else
                {
                    return Content("An error occurred while retrieving the weather.");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                return Content($"An error occurred: {ex.Message}");
            }
        }
    }
}
