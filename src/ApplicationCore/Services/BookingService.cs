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
        private readonly IPriceCalculatorService _priceCalculatorService;

        private const string InvalidDateErrorMessage =
            "Error, the Check-out date must be greater than the Check-in date.";

        public BookingService(IBookingRepository repository, ILodgingService lodgingService,
            IPriceCalculatorService priceCalculatorService)
        {
            _repository = repository;
            _lodgingService = lodgingService;
            _priceCalculatorService = priceCalculatorService;
        }

        public Booking Add(Booking booking)
        {
            booking.Lodging = _lodgingService.GetById(booking.Lodging.Id);
            booking.Code = Guid.NewGuid().ToString();
            booking.Price = GetPrice(booking);

            ValidateBooking(booking);

            UpdateLodgingCapacity(booking);

            return _repository.Add(booking);
        }

        private double GetPrice(Booking booking)
        {
            var totalDays = (int) (booking.CheckOutDate - booking.CheckInDate).TotalDays;
            var calculatedPrice =
                _priceCalculatorService.CalculatePrice(booking.NumberOfGuests, booking.Lodging.CostPerNight) *
                totalDays;
            return calculatedPrice;
        }

        private void ValidateBooking(Booking booking)
        {
            ValidateDates(booking.CheckInDate, booking.CheckOutDate);
            ValidateLodgingCapacity(booking);
        }

        private void ValidateDates(DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkInDate >= checkOutDate)
            {
                throw new InvalidAttributeValuesException(InvalidDateErrorMessage);
            }
        }

        private void ValidateLodgingCapacity(Booking booking)
        {
            var lodging = booking.Lodging;
            if (lodging.MaximumSize < (lodging.CurrentlyOccupiedPlaces + booking.TotalNumberOfGuests))
            {
                throw new InvalidAttributeValuesException("There is no place available for " +
                                                          booking.TotalNumberOfGuests +
                                                          " people");
            }
        }

        private void UpdateLodgingCapacity(Booking booking)
        {
            Lodging lodging = booking.Lodging;
            lodging.CurrentlyOccupiedPlaces += booking.TotalNumberOfGuests;
            _lodgingService.Update(lodging);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _repository.GetAll();
        }

        public Booking Get(string bookingCode)
        {
            return _repository.Get(bookingCode);
        }

        public void UpdateState(Booking booking)
        {
            _repository.UpdateState(booking);
        }
        
        public void UpdateReview(Booking booking)
        {
            _repository.UpdateReview(booking);
        }
    }
}