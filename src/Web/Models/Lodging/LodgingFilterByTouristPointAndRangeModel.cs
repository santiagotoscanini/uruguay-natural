using System;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingFilterByTouristPointAndRangeModel
    {
        [Required]
        public int TouristPointId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }

        public LodgingToFilter ToEntity()
        {
            return new LodgingToFilter
            {
                TouristPointId = TouristPointId,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate,
            };
        }
    }
}
