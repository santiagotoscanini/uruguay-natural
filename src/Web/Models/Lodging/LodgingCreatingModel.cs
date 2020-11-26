using System;
using Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Web.Models.LodgingModels
{
    public class LodgingCreatingModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int TouristPointId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IEnumerable<string> Images { get; set; }
        [Required]
        public double CostPerNight { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string DescriptionForBookings { get; set; }
        [Required]
        public int MaximumSize { get; set; }

        public Lodging ToEntity()
        {
            return new Lodging()
            {
                Name = this.Name,
                Address = this.Address,
                Images = this.Images.Select(image => Convert.FromBase64String(image)),
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
