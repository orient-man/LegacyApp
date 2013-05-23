﻿using System.Collections.Generic;

namespace LegacyApp.Web.Models
{
    public class User
    {
        public string Name { get; set; }

        public List<User> Friends { get; set; }

        public List<Trip> Trips { get; set; }

        public User()
        {
            Name = "";
            Friends = new List<User>();
            Trips = new List<Trip>();
        }

        public bool IsFriendWith(User user)
        {
            return Friends.Contains(user);
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as User);
        }

        public bool Equals(User u)
        {
            if (u == null)
                return false;

            return u.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}