
using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface IRegionService
    {
        IEnumerable<Region> GetAll();
    }
}
