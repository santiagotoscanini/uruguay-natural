using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.BookingModels;
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

        public void Update(BookingStateInfoModel updateBooking)
        {
            var Booking = _bookings.Find(updateBooking.Code);

            Booking.State = updateBooking.State;
            Booking.Description = updateBooking.Description;
            
            _bookings.Update(Booking);
            _context.SaveChanges();
        }
    }
}
