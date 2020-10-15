using Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.TouristPointModels
{
    public class TouristPointCreatingModel
    {
        public ICollection<string> Categories { get; set; }
        public string RegionName { get; set; }
        public string Name { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
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
