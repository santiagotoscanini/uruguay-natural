using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class TouristPointService : ITouristPointService
    {
        private readonly ITouristPointRepository _repository;
        private readonly ITouristPointCategoryRepository _touristPointCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRegionRepository _regionRepository;

        public TouristPointService(ITouristPointRepository repository, ITouristPointCategoryRepository touristPointCategoryRepository, ICategoryRepository categoryRepository, IRegionRepository regionRepository)
        {
            _repository = repository;
            _touristPointCategoryRepository = touristPointCategoryRepository;
            _categoryRepository = categoryRepository;
            _regionRepository = regionRepository;
        }
        public TouristPoint Add(TouristPoint touristPoint, ICollection<string> categories)
        {
            touristPoint.Region = _regionRepository.GetAll().First(r => r.Name == touristPoint.Region.Name);
            TouristPoint touristPointSaved = _repository.Add(touristPoint);
            foreach (string categoryName in categories)
            {
                Category category = getCategory(categoryName);
                addTouristPointCategory(touristPointSaved, category);
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
