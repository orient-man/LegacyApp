using NUnit.Framework;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Tests
{
    [TestFixture]
    public class UserTests
    {
        private static readonly User Bob = new UserBuilder().Named("Bob").Build();
        private static readonly User Alice = new UserBuilder().Named("Alice").Build();

        [Test]
        public void ShouldInformWhenUsersAreNotFriends()
        {
            // arrange
            var user = new UserBuilder().FriendsWith(Bob).Build();

            // act & assert
            Assert.That(user.IsFriendWith(Alice), Is.False);
        }

        [Test]
        public void ShouldInformWhenUsersAreFriends()
        {
            // arrange
            var user = new UserBuilder().FriendsWith(Bob, Alice).Build();

            // act & assert
            Assert.That(user.IsFriendWith(Alice), Is.True);
        }
    }
}