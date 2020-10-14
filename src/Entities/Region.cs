
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Region
    {
        public string Name { get; set; }
        public ICollection<TouristPoint> TouristPoints { get; set; }

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
