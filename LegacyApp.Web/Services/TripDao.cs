using System;
using System.Collections.Generic;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class TripDao : ITripDao
    {
        public List<Trip> FindTripsByUser(User user)
        {
            // SQL query here
            throw new NotImplementedException();
        }
    }
}