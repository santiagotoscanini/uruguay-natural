using System;
using System.Collections.Generic;

namespace Importers.Models
{
    public class LodgingParserModel
    {
        public string Name { get; set; }
        public TouristPointParserModel TouristPoint { get; set; }
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
        public double CostPerNight { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string DescriptionForBookings { get; set; }
        public int MaximumSize { get; set; }
    }
}