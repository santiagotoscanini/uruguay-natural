using Entities;

namespace Web.Models.LodgingModels
{
    public class LodgingUpdateCapacityModel
    {
        public int ActualCapacity { get; set; }

        public Lodging ToEntity(int id)
        {
            return new Lodging
            {
                CurrentlyOccupiedPlaces = this.ActualCapacity,
                Id = id
            };
        }
    }
}
