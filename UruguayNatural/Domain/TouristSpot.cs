using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
{
    public class TouristSpot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Region { get; set; }
        public ICollection<string> Features {get; set;}

        public TouristSpot(string name, string description, string image, string region, ICollection<string> features) 
        {
            Name = name;
            Description = description;
            Image = image;
            Region = region;
            Features = features;
        }
    }
}
