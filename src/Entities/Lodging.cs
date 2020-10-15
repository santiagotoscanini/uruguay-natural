using System.Collections.Generic;

namespace Entities
{
    public class Lodging
    {
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public TouristPoint TouristPoint { get; set; }
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int Id { get; set; }
        public int MaximumSize { get; set; }
        public int CurrentlyOccupiedPlaces { get; set; }
    }
}
