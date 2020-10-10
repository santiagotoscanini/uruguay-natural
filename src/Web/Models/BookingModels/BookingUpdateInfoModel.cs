using Entities;

namespace Web.Models.BookingModels
{
    public class BookingUpdateInfoModel
    {
        public BookingState State { get; set; }
        public string Description { get; set; }

        public Booking ToEntity(string code)
        {
            return new Booking()
            {
                Code = code,
                State = this.State,
                Description = this.Description,
            };
        }
    }
}
