using System.Collections.Generic;
using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingFilteredModel
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
        public int MaximumSize { get; set; }
        public int CurrentlyOccupiedPlaces { get; set; }
        public double CalculatedPrice { get; set; }

        public LodgingFilteredModel(Lodging lodging, double calculatedPrice)
        {
            Id = lodging.Id;
            Name = lodging.Name;
            TouristPoint = lodging.TouristPoint;
            Bookings = lodging.Bookings;
            Address = lodging.Address;
            Images = lodging.Images;
            CostPerNight = lodging.CostPerNight;
            Description = lodging.Description;
            MaximumSize = lodging.MaximumSize;
            CurrentlyOccupiedPlaces = lodging.CurrentlyOccupiedPlaces;
            CalculatedPrice = calculatedPrice;
            NumberOfStars = lodging.NumberOfStars;
        }
        
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is LodgingFilteredModel lodgingFilteredModel)
            {
                result = this.Id == lodgingFilteredModel.Id;
            }

            return result;
        }
    }
}
