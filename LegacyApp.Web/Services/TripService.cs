using System.Collections.Generic;
using System.Web;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            bool isFriend = false;

            var loggedUser = GetLoggedInUser();
            if (loggedUser != null)
            {
                foreach (User friend in user.Friends)
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    tripList = TripsByUser(user);
                }
            }
            else
            {
                throw new UserNotLoggedInException();
            }

            return tripList;
        }

        protected virtual List<Trip> TripsByUser(User user)
        {
            return TripDao.FindTripsByUser(user);
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
    }
}