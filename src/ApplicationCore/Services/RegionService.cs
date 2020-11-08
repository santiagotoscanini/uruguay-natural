using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repository;

        public RegionService(IRegionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Region> GetAll()
        {
            return _repository.GetAll();
        }

        public Region GetRegionByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}
