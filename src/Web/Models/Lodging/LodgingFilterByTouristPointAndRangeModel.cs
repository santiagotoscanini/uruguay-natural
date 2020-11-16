using System;
using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingFilterByTouristPointAndRangeModel
    {
        public int TouristPointId { get; set; }
        public DateTime CheckInDate { get; set; }
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
