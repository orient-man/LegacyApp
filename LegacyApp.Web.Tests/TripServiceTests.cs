using System.Collections.Generic;
using LegacyApp.Web.Models;
using NUnit.Framework;
using LegacyApp.Web.Services;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        private static readonly User Guest = null;
        private static readonly User UnusedUser = null;
        private static readonly User RegisteredUser = new User { Name = "Alice" };
        private static readonly User AnotherUser = new User { Name = "Bob" };
        private static readonly Trip ToBrazil = new Trip();
        private static readonly Trip ToLondon = new Trip();
        private static User loggedInUser;
        private TripService tripService;

        [SetUp]
        public void SetUpEachTest()
        {
            tripService = new TestableTripService();
        }

        [Test, ExpectedException(typeof (UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            // arrange
            loggedInUser = Guest;

            // act
            tripService.GetTripsByUser(UnusedUser);
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            // arrange
            loggedInUser = RegisteredUser;
            var friend = new User();
            friend.Friends.Add(AnotherUser);
            friend.Trips.Add(ToBrazil);

            // act
            var friendTrips = tripService.GetTripsByUser(friend);

            // assert
            Assert.That(friendTrips, Is.Empty);
        }

        [Test]
        public void ShouldReturnFriendTripsWhenUsersAreFriends()
        {
            // arrange
            loggedInUser = RegisteredUser;
            var friend = new User();
            friend.Friends.Add(AnotherUser);
            friend.Friends.Add(loggedInUser);
            friend.Trips.Add(ToBrazil);
            friend.Trips.Add(ToLondon);

            // act
            var friendTrips = tripService.GetTripsByUser(friend);

            // assert
            Assert.That(friendTrips.Count, Is.EqualTo(2));
        }

        private class TestableTripService : TripService
        {
            protected override User GetLoggedInUser()
            {
                return loggedInUser;
            }

            protected override List<Trip> TripsByUser(User user)
            {
                return user.Trips;
            }
        }
    }
}