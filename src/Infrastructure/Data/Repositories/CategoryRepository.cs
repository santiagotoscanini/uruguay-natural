using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Category> _categories;
        private const string CategoryAlreadyExistMessage = "There is already a category registered with the name: ";

        public CategoryRepository(DbContext context)
        {
            _context = context;
            _categories = context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }
        public Category Add(Category category)
        {
            try
            {
                Category categoryToReturn = _categories.Add(category).Entity;
                _context.SaveChanges();
                return categoryToReturn;
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(CategoryAlreadyExistMessage + category.Name);
            }
        }
    }
}
