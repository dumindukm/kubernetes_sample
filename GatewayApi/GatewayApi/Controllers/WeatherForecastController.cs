using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
//using System.Json;

namespace GatewayApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            Config = config;
        }

        public IConfiguration Config { get; }

        [HttpGet]
        [Route("api_version")]
        public IActionResult GetVersion()
        {
            return Ok("Version 2");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation(System.AppDomain.CurrentDomain.BaseDirectory);
            _logger.LogInformation(System.IO.File.Exists(System.IO.Path.Combine(Config.GetValue<string>("DataDirectory"),"file_share", "weather_forecast.json")).ToString());
            var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            return GetWeatherforecasts();
        }

        private IEnumerable<WeatherForecast> GetWeatherforecasts()
        {
            IEnumerable<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            var jsonPath = Path.Combine(Config.GetValue<string>("DataDirectory"), "file_share", "weather_forecast.json");
            StreamReader jsonReader = new StreamReader(jsonPath);
            var json = jsonReader.ReadToEnd();

            weatherForecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            return weatherForecasts;

        }
    }
}
