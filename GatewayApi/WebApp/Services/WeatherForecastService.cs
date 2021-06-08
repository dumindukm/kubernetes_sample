using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private HttpClient httpClient { get; }
        public WeatherForecastService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<List<WeatherForecastViewodel>> GetforecastsAsync()
        {
            List<WeatherForecastViewodel> forecasts = new List<WeatherForecastViewodel>();
            var response = await httpClient.GetAsync("WeatherForecast");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                forecasts = JsonConvert.DeserializeObject<List<WeatherForecastViewodel>>(content);
            }

            return forecasts;
        }

        public async Task<string> GetApiVersion()
        {
            string result = string.Empty;
            var response = await httpClient.GetAsync("WeatherForecast/api_version");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                result = await response.Content.ReadAsStringAsync();
                
            }

            return result;
        }

    }
}
