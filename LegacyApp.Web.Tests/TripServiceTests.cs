using LegacyApp.Web.Models;
using NUnit.Framework;
using LegacyApp.Web.Services;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        private const User Guest = null;
        private const User UnusedUser = null;
        private User loggedInUser;

        [Test, ExpectedException(typeof (UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            // arrange
            TripService tripService = new TestableTripService();
            loggedInUser = Guest;

            // act
            tripService.GetTripsByUser(UnusedUser);
        }

        private class TestableTripService : TripService
        {
            protected override User GetLoggedInUser(User loggedUser)
            {
                return loggedUser;
            }
        }
    }
}