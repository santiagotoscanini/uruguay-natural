using System;
using Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Models.TouristPointModels
{
    public class TouristPointModel
    {
        public ICollection<string> Categories { get; set; } = new List<string>();
        public string RegionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }

        public TouristPointModel(TouristPoint touristPoint)
        {
            SetCategoriesNames(touristPoint.TouristPointCategories);
            RegionName = touristPoint.Region.Name;
            Name = touristPoint.Name;
            Description = touristPoint.Description;
            Id = touristPoint.Id;
            Image = GetImage(touristPoint.Image);
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is TouristPointModel TouristPoint)
            {
                Result = this.Id == TouristPoint.Id;
            }

            return Result;
        }

        private void SetCategoriesNames(ICollection<TouristPointCategory> touristPointCategories)
        {
            foreach (TouristPointCategory touristPointCategory in touristPointCategories)
            {
                Categories.Add(touristPointCategory.Category.Name);
            }
        }

        private string GetImage(byte[] image)
        {
            var imageBase64 = Convert.ToBase64String(image);
            return string.Format("data:image/jpg;base64, {0}", imageBase64);
        }
    }
}
