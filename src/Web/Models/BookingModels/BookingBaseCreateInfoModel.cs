using Entities;

namespace Web.Models.BookingModels
{
    public class BookingBaseCreateInfoModel
    {
        public string Code { get; set; }

        public BookingBaseCreateInfoModel(Booking booking)
        {
            Code = booking.Code;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is BookingBaseCreateInfoModel Booking)
            {
                Result = this.Code == Booking.Code;
            }

            return Result;
        }
    }
}
