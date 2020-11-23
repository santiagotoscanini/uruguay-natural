using System.Collections.Generic;

namespace Entities
{
    public class TouristPoint
    {
        public ICollection<TouristPointCategory> TouristPointCategories { get; set; } = new List<TouristPointCategory>();
        public Region Region { get; set; }
        public string Name { get; set; }
        public ICollection<Lodging> Lodgings { get; set; } = new List<Lodging>();
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is TouristPoint touristPoint)
            {
                result = this.Id == touristPoint.Id;
            }

            return result;
        }
    }
}
