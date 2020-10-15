using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface ITouristPointService
    {
        TouristPoint Add(TouristPoint touristPoint, ICollection<string> categories);
        IEnumerable<TouristPoint> GetAll();
        IEnumerable<TouristPoint> GetAllFilteredByRegionAndCategory(string region, string category);
    }
}
