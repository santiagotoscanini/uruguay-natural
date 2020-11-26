using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Web.Models.BookingModels;

namespace Web.Models.LodgingModels
{
    public class LodgingFilteredModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public TouristPoint TouristPoint { get; set; }
        public IEnumerable<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public int MaximumSize { get; set; }
        public int CurrentlyOccupiedPlaces { get; set; }
        public double CalculatedPrice { get; set; }
        public int ReviewsCount { get; set; }

        public LodgingFilteredModel(Lodging lodging, double calculatedPrice)
        {
            Id = lodging.Id;
            Name = lodging.Name;
            TouristPoint = lodging.TouristPoint;
            Bookings = lodging.Bookings.Select(b => new BookingModel(b));
            Address = lodging.Address;
            Images = lodging.Images.Select(GetImage);
            CostPerNight = lodging.CostPerNight;
            Description = lodging.Description;
            MaximumSize = lodging.MaximumSize;
            CurrentlyOccupiedPlaces = lodging.CurrentlyOccupiedPlaces;
            CalculatedPrice = calculatedPrice;
            NumberOfStars = lodging.NumberOfStars;
            ReviewsCount = lodging.ReviewsCount;
        }
        
        private string GetImage(byte[] image)
        {
            var imageBase64 = Convert.ToBase64String(image);
            return string.Format("data:image/jpg;base64, {0}", imageBase64);
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
