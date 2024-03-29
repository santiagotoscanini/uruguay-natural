﻿using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class TouristPointService : ITouristPointService
    {
        private readonly ITouristPointRepository _touristPointRepository;

        private readonly ICategoryService _categoryService;
        private readonly IRegionService _regionService;

        public TouristPointService(ITouristPointRepository repository, ICategoryService categoryService, IRegionService regionService)
        {
            _touristPointRepository = repository;
            _categoryService = categoryService;
            _regionService = regionService;
        }

        public TouristPoint Add(TouristPoint touristPoint, ICollection<string> categories)
        {
            touristPoint.Region = _regionService.GetRegionByName(touristPoint.Region.Name);

            CreateTouristPointCategories(categories, touristPoint);

            return _touristPointRepository.Add(touristPoint);
        }

        private void CreateTouristPointCategories(ICollection<string> categories, TouristPoint touristPoint)
        {
            foreach (string categoryName in categories)
            {
                AddTouristPointCategory(touristPoint, categoryName);
            }
        }

        private void AddTouristPointCategory(TouristPoint touristPoint, string categoryName)
        {
            Category category = _categoryService.GetCategoryByName(categoryName);
            TouristPointCategory touristPointCategory = CreateTouristPointCategory(touristPoint, category);
            touristPoint.TouristPointCategories.Add(touristPointCategory);
        }

        private TouristPointCategory CreateTouristPointCategory(TouristPoint touristPoint, Category category)
        {
            return new TouristPointCategory
            {
                Category = category,
                TouristPoint = touristPoint
            };
        }

        public IEnumerable<TouristPoint> GetAll()
        {
            return _touristPointRepository.GetAll();
        }

        public IEnumerable<TouristPoint> GetAllFilteredByRegionAndCategory(string region, string category)
        {
            return _touristPointRepository.GetFilteredByRegionAndCategory(region, category);
        }

        public TouristPoint GetTouristPointById(int touristPointId)
        {
            return _touristPointRepository.GetById(touristPointId);
        }
    }
}
