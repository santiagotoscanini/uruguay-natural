using System;

namespace Entities
{
    public class Booking
    {
        public Tourist Tourist { get; set; }
        public string Code { get; set; }
        public BookingState State { get; set; }
        public string Description { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public Lodging Lodging { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Booking booking)
            {
                result = this.Code == booking.Code;
            }

            return result;
        }
    }
}
