using System.Collections.Generic;
using Entities;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IGuestRepository
    {
        IEnumerable<Guest> GetAll();
        Guest Add(Guest category);
    }
}