using System.Collections.Generic;

namespace LegacyApp.Web.Models
{
    public class User
    {
        public string Name { get; set; }

        public List<User> Friends { get; set; }

        public User()
        {
            Name = "";
            Friends = new List<User>();
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