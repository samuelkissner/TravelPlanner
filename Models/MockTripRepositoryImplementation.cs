using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models 
{
    public class MockTripRepositoryImplementation : ITripRepository
    {
        public ArrayList TripList;

        public Trip CreateTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Trip DeleteTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Trip EditTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Trip GetTrip(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
