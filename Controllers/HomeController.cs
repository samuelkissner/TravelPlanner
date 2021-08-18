using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelPlanner.Models;

namespace TravelPlanner.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripRepository _tripRepository;
        public HomeController(ILogger<HomeController> logger, ITripRepository tripRepository)
        {
            _logger = logger;
            _tripRepository = tripRepository;
        }

        public IActionResult Index()
        {

            return View(_tripRepository);
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
