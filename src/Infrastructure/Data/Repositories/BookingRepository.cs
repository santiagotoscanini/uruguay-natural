using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return _bookings.Include(b => b.Tourist);
        }

        public Booking Add(Booking booking)
        {
            Booking bookingToReturn =_bookings.Add(booking).Entity;
            _context.SaveChanges();
            return bookingToReturn;
        }

        public Booking Get(string code)
        {
            return _bookings.Include(b => b.Tourist).First(b => b.Code == code);
        }

        public void Update(Booking updateBooking)
        {
            var Booking = _bookings.Find(updateBooking.Code);

            Booking.State = updateBooking.State;
            Booking.Description = updateBooking.Description;
            
            _bookings.Update(Booking);
            _context.SaveChanges();
        }
    }
}
