
namespace Entities
{
    public class TouristPoint
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
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
