using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _repository;

        public AdministratorService(IAdministratorRepository repository)
        {
            _repository = repository;
        }

        public Administrator Add(Administrator administrator)
        {
            return _repository.Add(administrator);
        }

        public IEnumerable<Administrator> GetAll()
        {
            return _repository.GetAll();
        }

        public void DeleteAdministrator(string email)
        {
            _repository.DeleteAdministrator(email);
        }

        public void UpdateAdministrator(Administrator admin)
        {
            _repository.UpdateAdministrator(admin);
        }
    }
}
