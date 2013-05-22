using System;
using System.Collections.Generic;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class TripDao : ITripDao
    {
        public static List<Trip> FindTripsByUserStatic(User user)
        {
            // SQL query here
            throw new NotImplementedException();
        }

        public List<Trip> FindTripsByUser(User user)
        {
            return FindTripsByUserStatic(user);
        }
    }
}