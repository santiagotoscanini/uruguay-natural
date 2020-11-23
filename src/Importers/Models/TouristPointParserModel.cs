using System.Collections.Generic;

namespace Importers.Models
{
    public class TouristPointParserModel
    {
        public int Id { get; set; }
        public ICollection<string> Categories { get; set; }
        public string RegionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}