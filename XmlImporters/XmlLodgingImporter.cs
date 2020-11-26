using System;
using System.Collections.Generic;
using System.Xml;
using Importers;
using Importers.Models;

namespace XmlImporters
{
    public class XmlLodgingImporter : ILodgingImporter
    {
        private const string _xPath = "/lodgings/lodging";
        public IEnumerable<LodgingParserModel> Parse(string filePath)
        {
            var lodgingParserModels = new List<LodgingParserModel>();
            try {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                var xmlNodes = xmlDocument.SelectNodes(_xPath);
                if (xmlNodes == null) return lodgingParserModels;
                foreach (XmlNode xmlNode in xmlNodes)
                {
                    lodgingParserModels.Add(GetLodgingFromXml(xmlNode));
                }

                return lodgingParserModels;
            }
            catch (Exception)
            {
                return lodgingParserModels;
            }
        }

        private LodgingParserModel GetLodgingFromXml(XmlNode xmlNode)
        {
            var lodging = new LodgingParserModel
            {
                Name = xmlNode["name"]?.InnerText,
                TouristPoint = GetTouristPointParserModelFromXml(xmlNode["touristPoint"]),
                Address = xmlNode["address"]?.InnerText,
                Images = GetImagesFromXml(xmlNode["images"]),
                CostPerNight = Convert.ToDouble(xmlNode["costPerNight"]?.InnerText),
                Description = xmlNode["description"]?.InnerText,
                ContactNumber = xmlNode["contactNumber"]?.InnerText,
                DescriptionForBookings = xmlNode["descriptionForBookings"]?.InnerText,
                MaximumSize = Convert.ToInt32(xmlNode["maximumSize"]?.InnerText),
            };
            
            return lodging;
        }

        private IEnumerable<string> GetImagesFromXml(XmlNode xmlNode)
        {
            var images = new List<string>();
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                images.Add(node?.InnerText);
            }

            return images;
        }

        private TouristPointParserModel GetTouristPointParserModelFromXml(XmlNode xmlNode)
        {
            var touristPoint = new TouristPointParserModel
            {
                Id = Convert.ToInt32(xmlNode["id"]?.InnerText),
                Categories = GetCategoriesFromXml(xmlNode["categories"]),
                RegionName = xmlNode["regionName"]?.InnerText,
                Name = xmlNode["name"]?.InnerText,
                Description = xmlNode["description"]?.InnerText,
                Image = xmlNode["image"]?.InnerText,
                
            };
            return touristPoint;
        }

        private ICollection<string> GetCategoriesFromXml(XmlNode xmlNode)
        {
            var categories = new List<string>();
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                categories.Add(node?.InnerText);
            }

            return categories;
        }
    }
}