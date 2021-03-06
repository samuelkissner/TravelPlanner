using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models 
{
    public class MockTripRepositoryImplementation : ITripRepository
    {
        private List<Trip> _tripList;

        public MockTripRepositoryImplementation()
        {
            this._tripList = new List<Trip>
            {
                new Trip() {ID = 0, Name = "Tim's Wedding", Description = "Tim is having a destination wedding in Findland at the end of the year.", DepartureDate = new DateTime(12/05/2021), ReturnDate = new DateTime(12/11/2021), Budget = 5000 },
                new Trip() { ID = 1, Name = "Halloween Party", Description = "Attending a halloween-themed costume party at the company branch in Austin.", DepartureDate = new DateTime(10 / 28 / 2021), ReturnDate = new DateTime(11 / 01 / 2021), Budget = 600 },
                new Trip() { ID = 2, Name = "Carribean Cruise", Description = "Two week, all-inclusive.", DepartureDate = new DateTime(07/01/2022), ReturnDate = new DateTime(07/14/2022), Budget = 2500 },
            };
        }

        public Trip AddTrip(Trip trip)
        {
            int id = _tripList.Max(t => t.ID) + 1;
            trip.ID = id;
            this._tripList.Add(trip);
            return trip;
        }

        public Trip DeleteTrip(int id)
        {
            Trip trip = GetTrip(id);
            if(trip != null)
                this._tripList.Remove(trip);
            return trip;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return this._tripList;
        }

        public Trip GetTrip(int id)
        {
            return this._tripList.FirstOrDefault(t => t.ID == id); 
        }

        public Trip UpdateTrip(Trip tripChanges)
        {
            throw new NotImplementedException();
        }
    }
}
