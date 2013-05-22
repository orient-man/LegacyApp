using System.Collections.Generic;
using LegacyApp.Web.Models;

namespace LegacyApp.Web.Services
{
    public interface ITripDao
    {
        List<Trip> FindTripsByUser(User user);
    }
}