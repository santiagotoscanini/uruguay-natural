using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Category> _categories;

        private const string CategoryAlreadyExistMessage = "There is already a category registered with the name: ";
        private const string CategoryNotFoundMessage = "There is no category with the name: ";

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
                return AddAndReturnCategory(category);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(CategoryAlreadyExistMessage + category.Name);
            }
        }

        private Category AddAndReturnCategory(Category category)
        {
            Category categoryToReturn = _categories.Add(category).Entity;
            _context.SaveChanges();
            return categoryToReturn;
        }

        public Category GetByName(string name)
        {
            try
            {
                var category = _categories.First(c => c.Name == name);
                return category;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException(CategoryNotFoundMessage + name);
            }
        }
    }
}
