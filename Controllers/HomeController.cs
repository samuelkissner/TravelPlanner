using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelPlanner.Models;
using TravelPlanner.ViewModels;

namespace TravelPlanner.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripRepository _tripRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, ITripRepository tripRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _tripRepository = tripRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult CreateTrip(CreateTripViewModel tripDetails)
        {


            if (ModelState.IsValid)
            {
                string uniquePhotopath = ProcessUploadedFile(tripDetails);
                Trip trip = new Trip()
                {
                    Name = tripDetails.Name,
                    Description = tripDetails.Description,
                    DepartureDate = tripDetails.DepartureDate,
                    ReturnDate = tripDetails.ReturnDate,
                    Budget = tripDetails.Budget,
                    PhotoPath = uniquePhotopath
                };

                this._tripRepository.AddTrip(trip);
                return RedirectToAction("TripDetails", new { id = trip.ID });
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditTrip(int id)
        {


            Trip trip = this._tripRepository.GetTrip(id);
            EditTripViewModel editTripViewModel = new EditTripViewModel
            {
                ID = trip.ID,
                Name= trip.Name,
                Description = trip.Description,
                DepartureDate = trip.DepartureDate,
                ReturnDate = trip.ReturnDate,
                Budget = trip.Budget,
                ExistingPhotoPath = trip.PhotoPath
            };

            return View(editTripViewModel);
        }

        [HttpPost]
        public IActionResult EditTrip(EditTripViewModel tripDetails)
        {
            if (ModelState.IsValid)
            {
                Trip trip = this._tripRepository.GetTrip(tripDetails.ID);
                

                trip.Name = tripDetails.Name;
                trip.Description = tripDetails.Description;
                trip.DepartureDate = tripDetails.DepartureDate;
                trip.ReturnDate = tripDetails.ReturnDate;
                trip.Budget = tripDetails.Budget;

                if(tripDetails.Photo != null)
                {
                   if(tripDetails.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", tripDetails.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                   trip.PhotoPath = ProcessUploadedFile(tripDetails);
                }
                
                

                this._tripRepository.UpdateTrip(trip);
                return RedirectToAction("TripDetails", new { id = trip.ID });
            }
            return View();
        }

        public IActionResult DeleteTrip(int? id)
        {

            this._tripRepository.DeleteTrip(id ?? 0);
            return RedirectToAction("index");
        }

        private string ProcessUploadedFile(CreateTripViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);

                }
            }
            return uniqueFileName;
        }
    }
}
