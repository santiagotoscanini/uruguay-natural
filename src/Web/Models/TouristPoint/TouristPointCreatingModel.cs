using Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.TouristPointModels
{
    public class TouristPointCreatingModel
    {
        [Required]
        public ICollection<string> Categories { get; set; }
        [Required]
        public string RegionName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(2000, ErrorMessage = "The descriptionExceeds the limit of 2000 characters.")]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }

        public TouristPoint ToEntity()
        {
            return new TouristPoint()
            {
                Region = new Region { Name = this.RegionName },
                Name = this.Name,
                Description = this.Description,
                Image = this.Image
            };
        }
    }
}
