using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class LodgingRepository : ILodgingRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Lodging> _lodgings;

        private const string LodgingAlreadyExistMessage = "There is already a lodging registered with the id: ";
        private const string LodgingNotFoundMessage = "There is no lodging with the id: ";

        public LodgingRepository(DbContext context)
        {
            _context = context;
            _lodgings = context.Set<Lodging>();
        }

        public Lodging Add(Lodging lodging)
        {
            try
            {
                return AddAndReturnLodging(lodging);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(LodgingAlreadyExistMessage + lodging.Id);
            }
        }

        private Lodging AddAndReturnLodging(Lodging lodging)
        {
            Lodging lodgingToReturn = _lodgings.Add(lodging).Entity;
            _context.SaveChanges();
            return lodgingToReturn;
        }

        public Lodging GetById(int lodgingId)
        {
            try
            {
                var lodging = _lodgings.First(l => l.Id == lodgingId);
                return lodging;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException(LodgingNotFoundMessage + lodgingId);
            }
        }

        public Lodging Update(Lodging lodging)
        {
            Lodging lodgingSaved = GetById(lodging.Id);
            lodgingSaved.CurrentlyOccupiedPlaces = lodging.CurrentlyOccupiedPlaces;
            Lodging lodgingUpdated = _lodgings.Update(lodgingSaved).Entity;
            return lodgingUpdated;
        }

        public IEnumerable<Lodging> GetAll()
        {
            return _lodgings.Include(t => t.TouristPoint);
        }

        public void Delete(int lodgingId)
        {
            Lodging lodgingSaved = GetById(lodgingId);
            _lodgings.Remove(lodgingSaved);
            _context.SaveChanges();
        }
    }
}
