using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public interface ITripRepository
    {
        public Trip AddTrip(Trip trip);
        public Trip GetTrip(int id);
        public IEnumerable<Trip> GetAllTrips();
        public Trip UpdateTrip(Trip tripChanges);
        public Trip DeleteTrip(int id);
    }
}
