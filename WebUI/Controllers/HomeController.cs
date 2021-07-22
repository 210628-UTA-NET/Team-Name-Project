using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Task<WebUI.Models.JokeViewModel> joke = GetJoke();
            WebUI.Models.JokeViewModel jokeResult = joke.Result;
            return View(jokeResult);
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

        private async Task<WebUI.Models.JokeViewModel> GetJoke()
        {
            // create http client
            var client= new HttpClient();
            //bind address
            client.BaseAddress = new Uri("https://icanhazdadjoke.com/");
            // will return json body 
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            // send the request for a default joke
            var response = await client.GetStringAsync("/").ConfigureAwait(false);
            //deserialized to JokeViewModel 
            return JsonConvert.DeserializeObject<WebUI.Models.JokeViewModel>(response);
        }
        [HttpPost]
        public IActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }

    }
}
