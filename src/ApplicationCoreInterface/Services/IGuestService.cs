using System.Collections.Generic;
using Entities;

namespace ApplicationCoreInterface.Services
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAll();
    }
}