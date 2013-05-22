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
        private TripService tripService;

        [SetUp]
        public void SetUpEachTest()
        {
            tripService = new TestableTripService();
        }

        [Test, ExpectedException(typeof (UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            tripService.GetTripsByUser(UnusedUser, Guest);
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            // arrange
            var friend = new UserBuilder()
                .FriendsWith(AnotherUser)
                .WithTrips(ToBrazil)
                .Build();

            // act
            var friendTrips = tripService.GetTripsByUser(friend, RegisteredUser);

            // assert
            Assert.That(friendTrips, Is.Empty);
        }

        [Test]
        public void ShouldReturnFriendTripsWhenUsersAreFriends()
        {
            // arrange
            var friend = new UserBuilder()
                .FriendsWith(AnotherUser, RegisteredUser)
                .WithTrips(ToBrazil, ToLondon)
                .Build();

            // act
            var friendTrips = tripService.GetTripsByUser(friend, RegisteredUser);

            // assert
            Assert.That(friendTrips.Count, Is.EqualTo(2));
        }

        private class TestableTripService : TripService
        {
            protected override List<Trip> TripsByUser(User user)
            {
                return user.Trips;
            }
        }
    }
}