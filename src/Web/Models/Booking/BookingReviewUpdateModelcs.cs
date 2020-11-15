using Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.BookingModels
{
    public class BookingReviewUpdateInfoModel
    {
        [Required]
        public BookingState State { get; set; }

        [Required]
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
