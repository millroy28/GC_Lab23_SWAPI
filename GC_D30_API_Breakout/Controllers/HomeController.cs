using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GC_D30_API_Breakout.Models;

namespace GC_D30_API_Breakout.Controllers
{
    public class HomeController : Controller
    {
        private readonly SwapiDal SP = new SwapiDal();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
                  
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

        
        public IActionResult PersonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonSearch(int Id)
        {
            //want to use the DAL to search people by ID
            Person p = SP.GetPerson("people", Id);
            return View(p);
        }

        public IActionResult PlanetSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PlanetSearch(int Id)
        {
            Planet p = SP.GetPlanet("planets", Id);
            return View(p);
        }
        public IActionResult StarshipSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StarshipSearch(int Id)
        {
            Starship s = SP.GetStarship("starships", Id);
            return View(s);
        }
    }
}
