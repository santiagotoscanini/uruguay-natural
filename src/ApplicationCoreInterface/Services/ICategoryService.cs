
using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}
