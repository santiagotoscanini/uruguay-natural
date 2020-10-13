using Entities;
using System;

namespace Web.Models.BookingModels
{
    public class BookingModel
    {
        public Tourist Tourist { get; set; }
        public string Code { get; set; }
        public BookingState State { get; set; }
        public string Description { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }

        public BookingModel(Booking booking)
        {
            Tourist = booking.Tourist;
            Code = booking.Code;
            State = booking.State;
            Description = booking.Description;
            CheckInDate = booking.CheckInDate;
            CheckOutDate = booking.CheckOutDate;
            NumberOfGuests = booking.NumberOfGuests;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is BookingModel Booking)
            {
                Result = this.Code == Booking.Code;
            }

            return Result;
        }
    }
}