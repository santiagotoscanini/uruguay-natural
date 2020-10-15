using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class LodgingService : ILodgingService
    {
        private readonly ILodgingRepository _repository;

        public LodgingService(ILodgingRepository repository)
        {
            _repository = repository;
        }

        public Lodging Add(Lodging lodging)
        {
            return _repository.Add(lodging);
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
