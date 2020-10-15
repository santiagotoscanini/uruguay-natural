using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class LodgingService : ILodgingService
    {
        private readonly ILodgingRepository _repository;

        private ITouristPointService _touristPointService;

        public LodgingService(ILodgingRepository repository, ITouristPointService touristPointService)
        {
            _repository = repository;
            _touristPointService = touristPointService;
        }

        public Lodging Add(Lodging lodging, int touristPointId)
        {
            lodging.TouristPoint = GetTouristPoint(touristPointId);
            
            return _repository.Add(lodging);
        }

        private TouristPoint GetTouristPoint(int touristPointId)
        {
            return _touristPointService.GetAll().FirstOrDefault(tp => tp.Id == touristPointId);
        }

        public void Delete(int lodgingId)
        {
            _repository.Delete(lodgingId);
        }

        public IEnumerable<Lodging> GetAll()
        {
            return _repository.GetAll();
        }

        public Lodging GetById(int lodgingId)
        {
            return _repository.GetById(lodgingId);
        }

        public Lodging Update(Lodging lodging)
        {
            return _repository.Update(lodging);
        }
    }
}
