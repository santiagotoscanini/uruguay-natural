using Entities;

namespace Web.Models.BookingModels
{
    public class BookingBaseCreateModel
    {
        public string Code { get; set; }
        public string ContactNumber { get; set; }
        public string Information { get; set; }

        public BookingBaseCreateModel(Booking booking)
        {
            Code = booking.Code;
            ContactNumber = booking.Lodging.ContactNumber;
            Information = booking.Lodging.DescriptionForBookings;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is BookingBaseCreateModel Booking)
            {
                Result = Code == Booking.Code;
            }

            return Result;
        }
    }
}
