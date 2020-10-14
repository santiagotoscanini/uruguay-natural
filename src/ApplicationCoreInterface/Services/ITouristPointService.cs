using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface ITouristPointService
    {
        TouristPoint Add(TouristPoint touristPoint);
        IEnumerable<TouristPoint> GetAll();
    }
}
