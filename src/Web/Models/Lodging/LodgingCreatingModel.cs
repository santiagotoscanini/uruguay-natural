using Entities;
using System.Collections.Generic;

namespace Web.Models.LodgingModels
{
    public class LodgingCreatingModel
    {
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public int TouristPointId { get; set; }
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int MaximumSize { get; set; }

        public Lodging ToEntity()
        {
            return new Lodging()
            {
                Name = this.Name,
                NumberOfStars = this.NumberOfStars,
                Address = this.Address,
                Images = this.Images,
                CostPerNight = this.CostPerNight,
                Description = this.Description,
                ContactNumber = this.ContactNumber,
                DescriptionForBookings = this.DescriptionForBookings,
                MaximumSize = this.MaximumSize,
                CurrentlyOccupiedPlaces = 0,
            };
        }
    }
}
