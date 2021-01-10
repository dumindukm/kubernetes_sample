using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //using (var client = new System.Net.Http.HttpClient())
            //{
            //    // Call *mywebapi*, and display its response in the page
            //    var request = new System.Net.Http.HttpRequestMessage();
            //    request.RequestUri = new Uri("https://localhost:51443/WeatherForecast"); // ASP.NET 3 (VS 2019 only)
            //    //request.RequestUri = new Uri("http://localhost:51080/api/values/1"); // ASP.NET 2.x
            //    var response = await client.SendAsync(request);
            //    var msg = " and " + await response.Content.ReadAsStringAsync();
            //}

            //var client = new HttpClient();
            //client.BaseAddress = new Uri("http://gatewayapi/");
            ////HTTP GET
            //var responseTask = client.GetAsync("WeatherForecast");
            //responseTask.Wait();

            //var result = responseTask.Result;
            using (var client = new System.Net.Http.HttpClient())
            {
                // Call *mywebapi*, and display its response in the page
                var request = new System.Net.Http.HttpRequestMessage();
                var url = "https://172.23.16.1:51443/WeatherForecast";
                request.RequestUri = new Uri(url); // ASP.NET 3 (VS 2019 only)
                //request.RequestUri = new Uri("http://mywebapi/api/values/1"); // ASP.NET 2.x
                var response = await client.SendAsync(request);
                ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
