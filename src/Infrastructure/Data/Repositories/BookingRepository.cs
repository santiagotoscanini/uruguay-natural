using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly DbContext _context;
        private readonly DbSet<Booking> _bookings;
        private const string BookingNotFoundMessage = "There is no booking with the given code: ";
        private const string BookingAlreadyExistMessage = "There is already a booking registered with that code: ";

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
            try
            {
                Booking bookingToReturn = _bookings.Add(booking).Entity;
                _context.SaveChanges();
                return bookingToReturn;
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(BookingAlreadyExistMessage+booking.Code);
            }    
        }

        public Booking Get(string code)
        {
            try
            {
                var booking = _bookings.Include(b => b.Tourist).First(b => b.Code == code);
                return _bookings.Include(b => b.Tourist).First(b => b.Code == code);
            }
            catch(InvalidOperationException)
            {
                throw new NotFoundException(BookingNotFoundMessage+code);
            }
        }

        public void Update(Booking updateBooking)
        {
            var booking = FindBookingByCode(updateBooking.Code);

            booking.State = updateBooking.State;
            booking.Description = updateBooking.Description;
            
            _bookings.Update(booking);
            _context.SaveChanges();
        }

        private Booking FindBookingByCode(string code)
        {
            var booking = _bookings.Find(code);
            if(booking == null)
                throw new NotFoundException(BookingNotFoundMessage+code);
            return booking;
        }
    }
}
