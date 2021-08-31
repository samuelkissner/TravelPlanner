using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public interface ITripRepository
    {
        Trip AddTrip(Trip trip);
        Trip GetTrip(int id);
        IEnumerable<Trip> GetAllTrips();
        Trip UpdateTrip(Trip tripChanges);
        Trip DeleteTrip(int id);
    }
}
