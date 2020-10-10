using Entities;

namespace Models.BookingModels
{
    public class BookingUpdateInfoModel
    {
        public BookingState State { get; set; }
        public string Description { get; set; }

        public BookingStateInfoModel ToStateInfoModel(string code)
        {
            return new BookingStateInfoModel()
            {
                Code = code,
                State = this.State,
                Description = this.Description,
            };
        }
    }
}
