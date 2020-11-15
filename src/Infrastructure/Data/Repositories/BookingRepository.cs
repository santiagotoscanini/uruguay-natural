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

        private const string BookingNotFoundMessage = "There is no booking with the code ";
        private const string BookingAlreadyExistMessage = "There is already a booking registered with the code: ";

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
                return AddAndReturnBooking(booking);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(BookingAlreadyExistMessage+booking.Code);
            }    
        }

        private Booking AddAndReturnBooking(Booking booking)
        {
            Booking bookingToReturn = _bookings.Add(booking).Entity;
            _context.SaveChanges();
            return bookingToReturn;
        }

        public Booking Get(string code)
        {
            try
            {
                return GetBookingByCodeIncludingTourist(code);
            }
            catch(InvalidOperationException)
            {
                throw new NotFoundException(BookingNotFoundMessage+code);
            }
        }

        private Booking GetBookingByCodeIncludingTourist(string code)
        {
            return _bookings.Include(b => b.Tourist).First(b => b.Code == code);
        }

        public void Update(Booking updateBooking)
        {
            var booking = FindBookingByCode(updateBooking.Code);

            booking.State = updateBooking.State;
            booking.Description = updateBooking.Description;
            booking.TouristReview = updateBooking.TouristReview;
            
            _bookings.Update(booking);
            _context.SaveChanges();
        }

        private Booking FindBookingByCode(string code)
        {
            var booking = _bookings.Find(code);
            if(booking == null)
            {
                throw new NotFoundException(BookingNotFoundMessage + code);
            }

            return booking;
        }
    }
}
