using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Administrator> _administrators;

        public AdministratorRepository(DbContext context)
        {
            _context = context;
            _administrators = context.Set<Administrator>();
        }

        public Administrator Add(Administrator administrator)
        {
            Administrator adminToReturn = _administrators.Add(administrator).Entity;
            _context.SaveChanges();
            return adminToReturn;
        }

        public IEnumerable<Administrator> GetAll()
        {
            return _administrators;
        }
    }
}
