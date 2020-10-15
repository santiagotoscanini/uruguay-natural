using Entities;
using System.Collections.Generic;

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
            setCategoriesNames(touristPoint.TouristPointCategories);
            RegionName = touristPoint.Region.Name;
            Name = touristPoint.Name;
            Description = touristPoint.Description;
            Image = touristPoint.Description;
            Id = touristPoint.Id ?? default(int);
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

        private void setCategoriesNames(ICollection<TouristPointCategory> touristPointCategories)
        {
            foreach (TouristPointCategory touristPointCategory in touristPointCategories)
            {
                Categories.Add(touristPointCategory.Category.Name);
            }
        }
    }
}
