using System.Collections.Generic;

namespace Entities
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<TouristPointCategory> CategoryTouristPoints { get; set; } = new List<TouristPointCategory>();

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Category category)
            {
                result = this.Name == category.Name;
            }

            return result;
        }
    }
}
