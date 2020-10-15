using Entities;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface ILodgingService
    {
        IEnumerable<Lodging> GetAll();
        Lodging Add(Lodging lodging, int touristPointId);
        Lodging GetById(int lodgingId);
        Lodging Update(Lodging lodging);
        void Delete(int lodgingId);
    }
}
