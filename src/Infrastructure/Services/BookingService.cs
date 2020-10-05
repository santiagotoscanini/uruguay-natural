using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        public Booking Add(Booking booking)
        {
            throw new NotImplementedException();
        }

        //private readonly IRepository _repository;

        //public BookingService(IRepository repository)
        //{
        //    _repository = repository;
        //}
        //public Booking Add(Booking booking)
        //{
        //    return _repository.AddBooking(booking);
        //}

        public IEnumerable<Booking> GetAll()
        {
            return new List<Booking>(){new Booking(){Description="asdasd"}};
        }
    }
}
