using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class TouristPointService : ITouristPointService
    {
        private readonly ITouristPointRepository _TouristPointRepository;
        private readonly ITouristPointCategoryRepository _touristPointCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRegionRepository _regionRepository;

        public TouristPointService(ITouristPointRepository repository, ITouristPointCategoryRepository touristPointCategoryRepository, ICategoryRepository categoryRepository, IRegionRepository regionRepository)
        {
            _TouristPointRepository = repository;
            _touristPointCategoryRepository = touristPointCategoryRepository;
            _categoryRepository = categoryRepository;
            _regionRepository = regionRepository;
        }

        public TouristPoint Add(TouristPoint touristPoint, ICollection<string> categories)
        {
            touristPoint.Region = _regionRepository.GetAll().First(r => r.Name == touristPoint.Region.Name);

            foreach (string categoryName in categories)
            {
                Category category = getCategory(categoryName);
                TouristPointCategory touristPointCategory = createTouristPointCategory(touristPoint, category);
                touristPoint.TouristPointCategories.Add(touristPointCategory);
            }
            TouristPoint touristPointSaved = _TouristPointRepository.Add(touristPoint);
            return touristPointSaved;
        }

        private Category getCategory(string categoryName)
        {
            return _categoryRepository.GetByName(categoryName);
        }

        private TouristPointCategory createTouristPointCategory(TouristPoint touristPoint, Category category)
        {
            var touristPointCategory = new TouristPointCategory
            {
                Category = category,
                TouristPoint = touristPoint
            };
            return touristPointCategory;
        }

        public IEnumerable<TouristPoint> GetAll()
        {
            return _TouristPointRepository.GetAll();
        }
    }
}
