
using System.Data.Common;

namespace Entities
{
    public class TouristPointCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public TouristPoint TouristPoint { get; set; }
    }
}
