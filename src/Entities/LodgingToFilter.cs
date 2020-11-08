using System;

namespace Entities
{
    public class LodgingToFilter
    {
        public int TouristPointId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public NumberOfGuests NumberOfGuests { get; set; }
        public int TotalNumberOfGuests { get; set; }
    }
}