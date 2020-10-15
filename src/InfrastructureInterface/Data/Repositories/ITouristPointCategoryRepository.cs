using Entities;

namespace InfrastructureInterface.Data.Repositories
{
    public interface ITouristPointCategoryRepository
    {
        TouristPointCategory Add(TouristPointCategory touristPointCategory);
    }
}
