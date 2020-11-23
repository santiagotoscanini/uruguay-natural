using System;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingFilterModel
    {
        [Required]
        public int TouristPointId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfAdults { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfChildren { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfBabies { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfRetired { get; set; }

        public LodgingToFilter ToEntity()
        {
            var numberOfGuests = new NumberOfGuests
            {
                NumberOfAdults = NumberOfAdults,
                NumberOfChildren = NumberOfChildren,
                NumberOfBabies = NumberOfBabies,
                NumberOfRetired = NumberOfRetired
            };
            
            return new LodgingToFilter
            {
                TouristPointId = TouristPointId,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate,
                NumberOfGuests = numberOfGuests,
                TotalNumberOfGuests = numberOfGuests.GetTotalNumberOfGuests()
            };
        }
    }
}
