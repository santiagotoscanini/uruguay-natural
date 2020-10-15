using System.Collections.Generic;

namespace Entities
{
    public class Region
    {
        public string Name { get; set; }
        public ICollection<TouristPoint> TouristPoints { get; set; } = new List<TouristPoint>();

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Region region)
            {
                result = this.Name == region.Name;
            }

            return result;
        }
    }
}
