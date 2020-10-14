using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Add(Category category);
        Category GetByName(string name);
    }
}
