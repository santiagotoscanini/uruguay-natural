using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class TouristPointService : ITouristPointService
    {
        private readonly ITouristPointRepository _repository;
        private readonly ITouristPointCategoryRepository _touristPointCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TouristPointService(ITouristPointRepository repository, ITouristPointCategoryRepository touristPointCategoryRepository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _touristPointCategoryRepository = touristPointCategoryRepository;
            _categoryRepository = categoryRepository;
        }
        public TouristPoint Add(TouristPoint touristPoint, ICollection<string> categories)
        {
            TouristPoint touristPointSaved = _repository.Add(touristPoint);
            foreach (string categoryName in categories)
            {
                Category category = getCategory(categoryName);
                TouristPointCategory touristPointCategory = addTouristPointCategory(touristPointSaved, category);
                touristPointSaved.TouristPointCategories.Add(touristPointCategory);
            }
            return touristPointSaved;
        }

        private Category getCategory(string categoryName)
        {
            return _categoryRepository.GetByName(categoryName);
        }

        private TouristPointCategory addTouristPointCategory(TouristPoint touritsPoint, Category category)
        {
            var tourisyPointCategory = new TouristPointCategory
            {
                Category = category,
                TouristPoint = touritsPoint
            };
            return _touristPointCategoryRepository.Add(tourisyPointCategory);
        }

        public IEnumerable<TouristPoint> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
