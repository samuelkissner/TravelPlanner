using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class SQLTripRepositoryImplementation : ITripRepository
    {
        private readonly AppDbContext context;
        public SQLTripRepositoryImplementation(AppDbContext context)
        {
            this.context = context;
        }

        public Trip AddTrip(Trip trip)
        {
            this.context.Add(trip);
            this.context.SaveChanges();
            return trip;
        }

        public Trip DeleteTrip(int id)
        {
            Trip tripToDelete = GetTrip(id);
            if(tripToDelete != null)
            {
                this.context.Remove<Trip>(tripToDelete);
                this.context.SaveChanges();
            }
            
            return tripToDelete;
            
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return context.Trips;
        }

        public Trip GetTrip(int id)
        {
            return this.context.Find<Trip>(id);
        }

        public Trip UpdateTrip(Trip tripChanges) 
        {

            var trip = this.context.Trips.Attach(tripChanges);
            trip.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
            return tripChanges;
        }
    }
}
