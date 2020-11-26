using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Importers;
using Importers.Models;
using Newtonsoft.Json.Linq;

namespace JsonImporters
{
    public class JsonLodgingImporter : ILodgingImporter
    {
        private const string PATH_TO_LODGINGS = "lodgings";

        public IEnumerable<LodgingParserModel> Parse(string filePath)
        {
            var lodgingParserModels = new List<LodgingParserModel>();
            try
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var streamReader = new StreamReader(fileStream);
                var jsonData = streamReader.ReadToEnd();
                var objects = JObject.Parse(jsonData)[PATH_TO_LODGINGS].ToArray();
                foreach (var obj in objects)
                {
                    lodgingParserModels.Add(GetLodgingFromJson(obj));
                }

                return lodgingParserModels;
            }
            catch (Exception)
            {
                return lodgingParserModels;
            }
        }

        private LodgingParserModel GetLodgingFromJson(JToken token)
        {
            var lodging = new LodgingParserModel
            {
                Name = (string) token["name"],
                TouristPoint = GetTouristPointParserModel(token["touristPoint"]),
                Address = (string) token["address"],
                Images = token["images"].Select(e => e.ToString()),
                CostPerNight = (double) token["costPerNight"],
                Description = (string) token["description"],
                ContactNumber = (string) token["contactNumber"],
                DescriptionForBookings = (string) token["descriptionForBookings"],
                MaximumSize = (int) token["maximumSize"],
            };

            return lodging;
        }
        
        private TouristPointParserModel GetTouristPointParserModel(JToken token)
        {
            var touristPoint = new TouristPointParserModel
            {
                Id = (int) token["id"],
                Categories = token["categories"].Select(e => e.ToString()).ToList(),
                RegionName = (string) token["regionName"],
                Name = (string) token["name"],
                Description = (string) token["description"],
                Image = (string) token["image"],
            };
            
            return touristPoint;
        }
    }
}
