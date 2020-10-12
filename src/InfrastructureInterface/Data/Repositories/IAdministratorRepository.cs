using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IAdministratorRepository
    {
        Administrator Add(Administrator administrator);
        IEnumerable<Administrator> GetAll();
    }
}
