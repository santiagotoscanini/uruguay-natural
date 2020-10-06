using Entities;
using System;

namespace Web.Models
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

        public Booking ToEntity()
        {
            return new Booking()
            {
                Tourist = this.Tourist,
                Code = this.Code,
                State = this.State,
                Description = this.Description,
                CheckInDate = this.CheckInDate,
                CheckOutDate = this.CheckOutDate,
                NumberOfGuests = this.NumberOfGuests
            };
        }
    }
}