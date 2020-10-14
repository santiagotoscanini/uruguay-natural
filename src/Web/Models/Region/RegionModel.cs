using Entities;

namespace Web.Models.RegionModels
{
    public class RegionModel
    {
        public string Name { get; set; }

        public RegionModel(Region region)
        {
            Name = region.Name;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is RegionModel region)
            {
                Result = this.Name == region.Name;
            }

            return Result;
        }
    }
}
