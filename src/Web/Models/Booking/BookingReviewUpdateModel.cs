using Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.BookingModels
{
    public class BookingReviewUpdateModel
    {
        [Required]
        public string ReviewText { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "The points must be between zero and five.")]
        public int ReviewPoints { get; set; }

        public Booking ToEntity(string code)
        {
            var review = new Review
            {
                Text = ReviewText,
                NumberOfPoints = ReviewPoints,
            };
            return new Booking()
            {
                Code = code,
                TouristReview = review,
            };
        }

    }
}
