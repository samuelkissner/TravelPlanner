﻿using System;
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
            IEnumerable<Trip> model = this._tripRepository.GetAllTrips();
            return View(model);
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


        public IActionResult TripDetails(int? id)
        {
            var model = this._tripRepository.GetTrip(id ?? 1);
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrip(Trip trip)
        {
            if (ModelState.IsValid)
            {
                this._tripRepository.AddTrip(trip);
                return RedirectToAction("TripDetails", new { id = trip.ID });
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditTrip(int? id)
        {
            var model = this._tripRepository.GetTrip(id ?? 1);
            return View(model) ;
        }

        [HttpPost]
        public IActionResult EditTrip(Trip trip)
        {
            if (ModelState.IsValid)
            {
                this._tripRepository.UpdateTrip(trip);
                return RedirectToAction("TripDetails", new {id = trip.ID });
            }
            return View();
        }

        public IActionResult DeleteTrip(int? id)
        {
           
            this._tripRepository.DeleteTrip(id ?? 0);
            return RedirectToAction("index");
        }
    }
}
