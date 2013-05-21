using LegacyApp.Web.Models;
using NUnit.Framework;
using LegacyApp.Web.Services;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        private readonly User Guest = null;
        private readonly User UnusedUser = null;
        private readonly User RegisteredUser = new User { Name = "Alice" };
        private readonly User AnotherUser = new User { Name = "Bob" };
        private readonly Trip ToBrazil = new Trip();
        private static User loggedInUser;
        private TripService tripService;

        [Test, ExpectedException(typeof (UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            // arrange
            tripService = new TestableTripService();
            loggedInUser = Guest;

            // act
            tripService.GetTripsByUser(UnusedUser);
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            // arrange
            tripService = new TestableTripService();
            loggedInUser = RegisteredUser;
            var friend = new User();
            friend.Friends.Add(AnotherUser);
            friend.Trips.Add(ToBrazil);

            // act
            var friendTrips = tripService.GetTripsByUser(friend);

            // assert
            Assert.That(friendTrips, Is.Empty);
        }

        private class TestableTripService : TripService
        {
            protected override User GetLoggedInUser()
            {
                return loggedInUser;
            }
        }
    }
}