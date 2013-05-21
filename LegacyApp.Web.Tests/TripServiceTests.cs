using NUnit.Framework;
using LegacyApp.Web.Services;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        [Test, ExpectedException(typeof (UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            // arrange
            TripService tripService = new TestableTripService();

            // act
            tripService.GetTripsByUser(null);
        }

        private class TestableTripService : TripService
        {
            protected override Models.User GetLoggedInUser(Models.User loggedUser)
            {
                return null;
            }
        }
    }
}