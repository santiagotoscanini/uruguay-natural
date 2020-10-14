using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data.Repositories
{
    public class TouristPointCategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<TouristPointCategory> _touristPointCategories;

        public TouristPointCategoryRepository(DbContext context)
        {
            _context = context;
            _touristPointCategories = context.Set<TouristPointCategory>();
        }

        public TouristPointCategory Add(TouristPointCategory touristPointCategory)
        {
            try
            {
                TouristPointCategory touristPointToReturn = _touristPointCategories.Add(touristPointCategory).Entity;
                _context.SaveChanges();
                return touristPointToReturn;
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException("There is already a Tourist Point - Category relation with the id: " + touristPointCategory.Id);
            }
        }
    }
}
