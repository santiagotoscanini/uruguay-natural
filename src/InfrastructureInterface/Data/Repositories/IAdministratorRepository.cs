using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IAdministratorRepository
    {
        Administrator Add(Administrator administrator);
        IEnumerable<Administrator> GetAll();
        void DeleteAdministrator(string email);
        Administrator UpdateAdministrator(Administrator admin);
    }
}
