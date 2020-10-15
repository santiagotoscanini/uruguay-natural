using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class TouristPointRepository : ITouristPointRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<TouristPoint> _touristPoints;

        private const string TouristPointAlreadyExistMessage = "There is already a tourist point registered with the id: ";

        public TouristPointRepository(DbContext context)
        {
            _context = context;
            _touristPoints = context.Set<TouristPoint>();
        }

        public IEnumerable<TouristPoint> GetAll()
        {
            return _touristPoints.Include(r => r.Region).Include(c => c.TouristPointCategories).ThenInclude(tp => tp.Category);
        }

        public TouristPoint Add(TouristPoint touristPoint)
        {
            try
            {
                return AddAndReturnTouristPoint(touristPoint);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(TouristPointAlreadyExistMessage + touristPoint.Id);
            }
        }

        private TouristPoint AddAndReturnTouristPoint(TouristPoint touristPoint)
        {
            TouristPoint touristPointToReturn = _touristPoints.Add(touristPoint).Entity;
            _context.SaveChanges();
            return touristPointToReturn;
        }
    }
}
