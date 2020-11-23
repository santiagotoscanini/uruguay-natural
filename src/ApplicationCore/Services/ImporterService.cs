using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApplicationCoreInterface.Services;
using Entities;
using Exceptions;
using Importers;

namespace ApplicationCore.Services
{
    public class ImporterService : IImporterService
    {
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        private DirectoryInfo _directory;
        private ITouristPointService _touristPointService;
        private ILodgingService _lodgingService;

        public ImporterService(ITouristPointService touristPointService, ILodgingService lodgingService)
        {
            _directory = new DirectoryInfo(_path);
            _touristPointService = touristPointService;
            _lodgingService = lodgingService;
        }

        public IEnumerable<string> GetNames()
        {
            IEnumerable<Type> implementations = GetImplementations();
            var names = implementations.Select(t => t.FullName);
            return names;
        }

        private IEnumerable<Type> GetImplementations()
        {
            FileInfo[] files = _directory.GetFiles("*.dll");
            IEnumerable<Type> implementations = new List<Type>();
            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementations = assemblyLoaded.GetTypes().Where(t => typeof(ILodgingImporter).IsAssignableFrom(t) && t.IsClass);
                implementations = implementations.Union(loadedImplementations);
            }

            return implementations;
        }

        public void Import(string importerName, string filePath)
        {
            var importer = GetImplementation(importerName);
            var lodging = importer.Parse(filePath).Select(l =>
                {
                    var touristPoint = new TouristPoint
                    {
                        Id = l.TouristPoint.Id,
                        Region = new Region{ Name = l.TouristPoint.RegionName},
                        Name = l.TouristPoint.Name,
                        Description = l.TouristPoint.Description,
                        Image = Convert.FromBase64String(l.TouristPoint.Image),
                    };
                    if (touristPoint.Id == 0)
                    {
                        touristPoint = _touristPointService.Add(touristPoint, l.TouristPoint.Categories);
                    }
                    return new Lodging
                    {
                        Name = l.Name,
                        Address = l.Address,
                        Images = l.Images.Select(Convert.FromBase64String),
                        CostPerNight = l.CostPerNight,
                        Description = l.Description,
                        ContactNumber = l.ContactNumber,
                        DescriptionForBookings = l.DescriptionForBookings,
                        MaximumSize = l.MaximumSize,
                        TouristPoint = touristPoint,
                    };
                });
            SaveLodgings(lodging);
        }
        
        private ILodgingImporter GetImplementation(string name)
        {
            try
            {
                var implementation = GetImplementations().First(i => i.FullName.Equals(name));
                return Activator.CreateInstance(implementation) as ILodgingImporter;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("The importer "+ name +" does not exist");
            }

        }

        private void SaveLodgings(IEnumerable<Lodging> lodgings)
        {
            foreach (var lodging in lodgings)
            {
                _lodgingService.Add(lodging, lodging.TouristPoint.Id);
            }
        }
    }
}