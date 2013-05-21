using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public class UserDao
    {
        public static User GetByName(string name)
        {
            // stinking SQL query here
            return new User { Name = name };
        }
    }
}