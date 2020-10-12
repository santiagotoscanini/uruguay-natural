using Entities;

namespace Web.Models.BookingModels
{
    public class BookingBaseCreateModel
    {
        public string Code { get; set; }

        public BookingBaseCreateModel(Booking booking)
        {
            Code = booking.Code;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is BookingBaseCreateModel Booking)
            {
                Result = this.Code == Booking.Code;
            }

            return Result;
        }
    }
}
