using System.Collections.Generic;

namespace Entities
{
    public class Lodging
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public TouristPoint TouristPoint { get; set; }
        public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int MaximumSize { get; set; }
        public int CurrentlyOccupiedPlaces { get; set; }
    }
}
