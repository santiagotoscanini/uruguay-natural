using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Lodging : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public TouristPoint TouristPoint { get; set; }
        public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        public string Address { get; set; }
        public IEnumerable<byte[]> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int MaximumSize { get; set; }
        public int CurrentlyOccupiedPlaces { get; set; }
        public int ReviewsCount { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Lodging lodging)
            {
                result = this.Id == lodging.Id;
            }

            return result;
        }

        public int CompareTo(object obj)
        {
            var lodging = (Lodging) obj;
            return this.Bookings.Count().CompareTo(lodging.Bookings.Count());
        }
    }
}
