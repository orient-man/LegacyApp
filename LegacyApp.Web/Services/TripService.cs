using System.Collections.Generic;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class TripService
    {
        private readonly ITripDao tripDao;

        // optional
        public TripService() : this(new TripDao()) { }

        public TripService(ITripDao tripDao)
        {
            this.tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user, User loggedInUser)
        {
            if (loggedInUser == null)
                throw new UserNotLoggedInException();

            return user.IsFriendWith(loggedInUser)
                ? TripsByUser(user)
                : NotTrips();
        }

        private List<Trip> TripsByUser(User user)
        {
            return tripDao.FindTripsByUser(user);
        }

        private List<Trip> NotTrips()
        {
            return new List<Trip>();
        }
    }
}