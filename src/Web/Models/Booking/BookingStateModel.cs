using Entities;

namespace Web.Models.BookingModels
{
    public class BookingStateInfoModel
    {
        public string Code { get; set; }
        public BookingState State { get; set; }
        public string Description { get; set; }

        public BookingStateInfoModel(Booking booking)
        {
            Code = booking.Code;
            State = booking.State;
            Description = booking.Description;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is BookingStateInfoModel Booking)
            {
                Result = this.Code == Booking.Code;
            }

            return Result;
        }
    }
}
