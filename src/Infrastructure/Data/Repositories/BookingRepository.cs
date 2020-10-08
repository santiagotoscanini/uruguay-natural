using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly DbContext _context;
        private readonly DbSet<Booking> _bookings;

        public BookingRepository(DbContext context)
        {
            _context = context;
            _bookings = context.Set<Booking>();
        }

        public IEnumerable<Booking> GetAll()
        {
            return _bookings;
        }

        public Booking Add(Booking booking)
        {
            _bookings.Add(booking);
            _context.SaveChanges();
            return Get(booking.Code);
        }

        public Booking Get(string code)
        {
            return _bookings.Find(code);
        }

        public void Update(Booking booking)
        {
            _bookings.Update(booking);
            _context.SaveChanges();
        }
    }
}
