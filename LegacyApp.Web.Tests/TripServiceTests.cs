using LegacyApp.Web.Infrastructure;
using LegacyApp.Web.Models;
using LegacyApp.Web.Services;
using Moq;
using NUnit.Framework;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        #region [ SetUp ]
        private static readonly User Guest = null;
        private static readonly User UnusedUser = null;
        private static readonly User RegisteredUser = new User { Name = "Alice" };
        private static readonly User AnotherUser = new User { Name = "Bob" };
        private static readonly Trip ToBrazil = new Trip();
        private static readonly Trip ToLondon = new Trip();

        private ITripDao tripDao;
        private TripService tripService;

        [SetUp]
        public void SetUpEachTest()
        {
            tripDao = new Mock<ITripDao> { DefaultValue = DefaultValue.Mock }.Object;
            ServiceLocator.Instance.Rebind<ITripDao>().ToConstant(tripDao);
            tripService = ServiceLocator.GetService<TripService>();
        }
        #endregion

        [Test, ExpectedException(typeof(UserNotLoggedInException))]
        public void ShouldThrowAnExceptionWhenNotLoggedIn()
        {
            tripService.GetFriendTrips(UnusedUser, Guest);
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
            var friendTrips = tripService.GetFriendTrips(friend, RegisteredUser);

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
            Mock.Get(tripDao)
                .Setup(o => o.FindTripsByUser(friend))
                .Returns(friend.Trips);

            // act
            var friendTrips = tripService.GetFriendTrips(friend, RegisteredUser);

            // assert
            Assert.That(friendTrips.Count, Is.EqualTo(2));
        }
    }
}