
using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Region Add(Region region);
    }
}
