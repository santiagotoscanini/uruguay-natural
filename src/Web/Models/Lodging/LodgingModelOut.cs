﻿using Entities;
using System.Collections.Generic;

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
            Images = lodging.Images;
            CostPerNight = lodging.CostPerNight;
            Description = lodging.Description;
            ContactNumber = lodging.ContactNumber;
            DescriptionForBookings = lodging.DescriptionForBookings;
            MaximumSize = lodging.MaximumSize;
        }
    }
}