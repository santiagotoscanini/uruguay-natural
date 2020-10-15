using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Administrator> _administrators;

        private const string AdministratorAlreadyExistMessage = "There is already a administrator registered with the email ";
        private const string AdministratorNotFound = "There is not an a administrator registered with the email ";

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

        public void DeleteAdministrator(string email)
        {
            Administrator admin = GetAdminByEmail(email);
            _administrators.Remove(admin);
            _context.SaveChanges();
        }

        private Administrator GetAdminByEmail(string email)
        {
            try
            {
                var admin = _administrators.First(a => a.Email == email);
                return admin;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException(AdministratorNotFound + email);
            }
        } 

        public Administrator UpdateAdministrator(Administrator admin)
        {
            Administrator adminSaved = GetAdminByEmail(admin.Email);
            if (admin.Password != null)
            {
                adminSaved.Password = admin.Password;
            }
            if (admin.Name != null)
            {
                adminSaved.Name = admin.Name;
            }
            Administrator adminUpdated = _administrators.Update(adminSaved).Entity;
            _context.SaveChanges();
            return adminUpdated;
        }
    }
}
