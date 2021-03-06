﻿using LegacyApp.Web.Models;

namespace LegacyApp.Web.Tests
{
    public class UserBuilder
    {
        private readonly User user = new User();

        public UserBuilder()
        {
            Named(new object().GetHashCode().ToString());
        }

        public UserBuilder Named(string name)
        {
            user.Name = name;
            return this;
        }

        public UserBuilder FriendsWith(params User[] friends)
        {
            user.Friends.AddRange(friends);
            return this;
        }

        public UserBuilder WithTrips(params Trip[] trips)
        {
            user.Trips.AddRange(trips);
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}