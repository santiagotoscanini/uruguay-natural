using System;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingFilterModel
    {
        public int TouristPointId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfAdults { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfChildren { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfBabies { get; set; }

        public LodgingToFilter ToEntity()
        {
            return new LodgingToFilter
            {
                TouristPointId = TouristPointId,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate,
                NumberOfGuests = new NumberOfGuests
                {
                  NumberOfAdults  = NumberOfAdults,
                  NumberOfChildren = NumberOfChildren,
                  NumberOfBabies = NumberOfBabies
                },
                TotalNumberOfGuests = GetTotalCountOfGuests()
            };
        }

        private int GetTotalCountOfGuests()
        {
            return NumberOfAdults + NumberOfChildren + NumberOfBabies;
        }
    }
}
