using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface IAdministratorService
    {
        Administrator Add(Administrator admin);
        IEnumerable<Administrator> GetAll();
        void DeleteAdministrator(string email);
        void UpdateAdministrator(Administrator admin);
    }
}
