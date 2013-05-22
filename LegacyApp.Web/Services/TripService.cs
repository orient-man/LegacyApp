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

        public List<Trip> GetFriendTrips(User friend, User loggedInUser)
        {
            if (loggedInUser == null)
                throw new UserNotLoggedInException();

            return friend.IsFriendWith(loggedInUser)
                ? TripsByUser(friend)
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