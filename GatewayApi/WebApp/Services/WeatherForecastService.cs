using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class WeatherForecastService
    {
        private HttpClient httpClient { get; }
        public WeatherForecastService(HttpClient client)
        {
            httpClient = client;
        }

        public List<WeatherForecastViewodel> Getforecasts()
        {
            List<WeatherForecastViewodel> forecasts = new List<WeatherForecastViewodel>();

            return forecasts;
        }

    }
}
