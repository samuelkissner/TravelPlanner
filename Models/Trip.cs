using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class Trip
    {
        public int ID { get; set; }   
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? Budget { get; set; }
        public string PhotoPath { get; set; }
    }
}
