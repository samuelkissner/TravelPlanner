using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.ViewModels
{
    public class CreateTripViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? Budget { get; set; }
        public IFormFile Photo { get; set; }
    }
}
