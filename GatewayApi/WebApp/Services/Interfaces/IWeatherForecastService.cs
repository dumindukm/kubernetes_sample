using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecastViewodel>> GetforecastsAsync();
    }
}
