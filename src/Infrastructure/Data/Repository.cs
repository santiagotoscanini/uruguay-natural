using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class Repository : IRepository
    {

        private readonly TourismContext _context;
        private readonly DbSet<Booking> _bookings;

        public Repository(TourismContext context)
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
