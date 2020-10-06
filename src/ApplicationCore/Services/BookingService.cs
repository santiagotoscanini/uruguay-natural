using Entities;
using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository _repository;

        public BookingService(IRepository repository)
        {
           _repository = repository;
        }
        public Booking Add(Booking booking)
        {
           return _repository.AddBooking(booking);
        }

        public IEnumerable<Booking> GetAll()
        {
            return new List<Booking>(){new Booking(){Description="asdasd"}};
        }
    }
}
