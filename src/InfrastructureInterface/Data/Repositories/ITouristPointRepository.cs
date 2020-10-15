using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface ITouristPointRepository
    {
        IEnumerable<TouristPoint> GetAll();
        TouristPoint Add(TouristPoint touristPoint);
        IEnumerable<TouristPoint> GetFilteredByRegionAndCategory(string region, string category);
    }
}
