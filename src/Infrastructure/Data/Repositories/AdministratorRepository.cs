using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Administrator> _administrators;

        private const string AdministratorAlreadyExistMessage = "There is already a administrator registered with the email ";

        public AdministratorRepository(DbContext context)
        {
            _context = context;
            _administrators = context.Set<Administrator>();
        }

        public Administrator Add(Administrator administrator)
        {
            try
            {
                return AddAndReturnAdmin(administrator);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(AdministratorAlreadyExistMessage + administrator.Email);
            }
        }

        private Administrator AddAndReturnAdmin(Administrator admin)
        {
            Administrator adminToReturn = _administrators.Add(admin).Entity;
            _context.SaveChanges();
            return adminToReturn;
        }

        public IEnumerable<Administrator> GetAll()
        {
            return _administrators;
        }
    }
}
