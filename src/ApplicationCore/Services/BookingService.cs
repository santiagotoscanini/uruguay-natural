﻿using Entities;
using System;
using System.Collections.Generic;
using ApplicationCoreInterface.Services;
using InfrastructureInterface.Data.Repositories;

namespace ApplicationCore.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
           _repository = repository;
        }
        public Booking Add(Booking booking)
        {
           return _repository.Add(booking);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _repository.GetAll();
        }

        public Booking Get(string bookingCode)
        {
            return _repository.Get(bookingCode);
        }

        public void Update(Booking booking)
        {
            _repository.Update(booking);
        }
    }
}
