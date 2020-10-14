using Entities;
using System.Collections.Generic;
using ApplicationCoreInterface.Services;
using InfrastructureInterface.Data.Repositories;
using System;
using Exceptions;

namespace ApplicationCore.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private const string InvalidDateErrorMessage = "Error, the Check-out date must be greater than the Check-in date.";

        public BookingService(IBookingRepository repository)
        {
           _repository = repository;
        }
        public Booking Add(Booking booking)
        {
            validateDates(booking.CheckInDate, booking.CheckOutDate);
            booking.Code = Guid.NewGuid().ToString();
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

        private void validateDates(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn >= checkOut) {
                throw new InvalidAttributeValuesException(InvalidDateErrorMessage);
            }
        }
    }
}
