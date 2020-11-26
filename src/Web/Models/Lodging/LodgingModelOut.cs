using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using Web.Models.BookingModels;

namespace Web.Models.LodgingModels
{
    public class LodgingModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStars { get; set; }
        public int TouristPointId { get; set; }
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public IEnumerable<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int MaximumSize { get; set; }

        public LodgingModelOut(Lodging lodging)
        {
            Id = lodging.Id;
            Name = lodging.Name;
            NumberOfStars = lodging.NumberOfStars;
            TouristPointId = lodging.TouristPoint.Id;
            Address = lodging.Address;
            Images = lodging.Images.Select(GetImage);
            Bookings = lodging.Bookings.Select(b => new BookingModel(b));
            CostPerNight = lodging.CostPerNight;
            Description = lodging.Description;
            ContactNumber = lodging.ContactNumber;
            DescriptionForBookings = lodging.DescriptionForBookings;
            MaximumSize = lodging.MaximumSize;
        }
        
        private string GetImage(byte[] image)
        {
            var imageBase64 = Convert.ToBase64String(image);
            return string.Format("data:image/jpg;base64, {0}", imageBase64);
        }
    }
}
