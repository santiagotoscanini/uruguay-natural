using System;
using System.Collections.Generic;
using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Guest> _guests;

        private const string GuestAlreadyExistMessage = "There is already a guest type registered with the name: ";

        public GuestRepository(DbContext context)
        {
            _context = context;
            _guests = context.Set<Guest>();
        }

        public IEnumerable<Guest> GetAll()
        {
            return _guests;
        }

        public Guest Add(Guest guest)
        {
            try
            {
                Guest guestToReturn = _guests.Add(guest).Entity;
                _context.SaveChanges();
                return guestToReturn;
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(GuestAlreadyExistMessage + guest.Name);
            }
        }
    }
}
