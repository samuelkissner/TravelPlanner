using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    interface ITripRepository
    {
        public Trip CreateTrip(Trip trip);
        public Trip GetTrip(Trip trip);
        public Trip EditTrip(Trip trip);
        public Trip DeleteTrip(Trip trip);
    }
}
