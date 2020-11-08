using System.Collections.Generic;
using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;

namespace ApplicationCore.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repository;

        public GuestService(IGuestRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Guest> GetAll()
        {
            return _repository.GetAll();
        }
    }
}