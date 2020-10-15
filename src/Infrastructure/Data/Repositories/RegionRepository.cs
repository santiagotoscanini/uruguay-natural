using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Region> _regions;
        private const string RegionAlreadyExistMessage = "There is already a region registered with the name: ";

        public RegionRepository(DbContext context)
        {
            _context = context;
            _regions = context.Set<Region>();
        }

        public IEnumerable<Region> GetAll()
        {
            return _regions;
        }

        public Region Add(Region region)
        {
            try
            {
                return AddAndReturnRegion(region);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(RegionAlreadyExistMessage + region.Name);
            }
        }

        private Region AddAndReturnRegion(Region region)
        {
            Region regionToReturn = _regions.Add(region).Entity;
            _context.SaveChanges();
            return regionToReturn;
        }
    }
}
