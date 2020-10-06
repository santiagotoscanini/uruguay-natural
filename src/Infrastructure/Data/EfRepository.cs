using Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class EfRepository : IRepository
    {

        private readonly TourismContext _context;
        private readonly DbSet<Booking> _bookings;

        public EfRepository(TourismContext context)
        {
            _context = context;
            _bookings = context.Set<Booking>();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookings;
        }

        public Booking AddBooking(Booking booking)
        {
            _bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }
    }
}
