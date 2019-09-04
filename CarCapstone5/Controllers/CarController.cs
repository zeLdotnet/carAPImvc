using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarCapstone5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarCapstone5.Controllers
{
    public class CarController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44386");

            var response = await client.GetAsync("api/car");
            var result = await response.Content.ReadAsAsync<List<Car>>();
            return View(result);
        }

        public async Task<IActionResult> SearchMake(string make)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44386");

            var response = await client.GetAsync($"api/car/{make}");
            var result = response.Content.ReadAsStringAsync();

            var cars = JsonConvert.DeserializeObject<List<Car>>(await result);
            return View(cars);

        }
    }
}