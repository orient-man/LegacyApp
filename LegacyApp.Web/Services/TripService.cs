using System.Collections.Generic;
using System.Web;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            var loggedInUser = GetLoggedInUser();
            if (loggedInUser == null)
                throw new UserNotLoggedInException();

            return user.IsFriendWith(loggedInUser)
                ? TripsByUser(user)
                : NotTrips();
        }

        protected virtual User GetLoggedInUser()
        {
            User loggedUser = null;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                loggedUser = UserDao.GetByName(
                    HttpContext.Current.User.Identity.Name);
            }
            return loggedUser;
        }

        protected virtual List<Trip> TripsByUser(User user)
        {
            return TripDao.FindTripsByUser(user);
        }

        private List<Trip> NotTrips()
        {
            return new List<Trip>();
        }
    }
}