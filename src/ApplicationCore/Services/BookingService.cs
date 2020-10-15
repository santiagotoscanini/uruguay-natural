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
        private readonly ILodgingService _lodgingService;

        private const string InvalidDateErrorMessage = "Error, the Check-out date must be greater than the Check-in date.";

        public BookingService(IBookingRepository repository, ILodgingService lodgingService)
        {
           _repository = repository;
            _lodgingService = lodgingService;
        }
        public Booking Add(Booking booking)
        {
            ValidateDates(booking.CheckInDate, booking.CheckOutDate);
            booking.Code = Guid.NewGuid().ToString();
            booking.Lodging = _lodgingService.GetById(booking.Lodging.Id);
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

        private void ValidateDates(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn >= checkOut) {
                throw new InvalidAttributeValuesException(InvalidDateErrorMessage);
            }
        }
    }
}
