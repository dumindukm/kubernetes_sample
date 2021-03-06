﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService weatherservice;

        public WeatherForecastController(IWeatherForecastService weatherservice)
        {
            this.weatherservice = weatherservice;
        }

        // GET: WeatherForecastController
        public async Task<ActionResult> Index()
        {
            List<WeatherForecastViewodel> forecasts = new List<WeatherForecastViewodel>();
            forecasts = await this.weatherservice.GetforecastsAsync();
            return View(forecasts);
        }

        public async Task<ActionResult> ApiVersion()
        {
            var apiVersion = await this.weatherservice.GetApiVersion();
            ViewBag.Version = "ViewBag " + apiVersion.Length;
            return View("ApiVersion",apiVersion);
        }

        // GET: WeatherForecastController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherForecastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherForecastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherForecastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherForecastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
