using Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface ILodgingRepository
    {
        IEnumerable<Lodging> GetAll();
        Lodging Add(Lodging lodging);
        void Delete(int lodgingId);
        Lodging Update(Lodging lodging);
        Lodging GetById(int lodgingId);
    }
}
