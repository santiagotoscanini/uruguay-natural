using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class TouristPointService : ITouristPointService
    {
        private readonly ITouristPointRepository _repository;

        public TouristPointService(ITouristPointRepository repository)
        {
            _repository = repository;
        }
        public TouristPoint Add(TouristPoint touristPoint)
        {
            return _repository.Add(touristPoint);
        }

        public IEnumerable<TouristPoint> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
