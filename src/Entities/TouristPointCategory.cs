
namespace Entities
{
    public class TouristPointCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public TouristPoint TouristPoint { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is TouristPointCategory touristPointCategory)
            {
                result = this.Id == touristPointCategory.Id;
            }

            return result;
        }
    }
}
