using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SessionInterface;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection _services;

        public ServiceFactory(IServiceCollection services)
        {
            _services = services;
        }

        public void AddCustomServices()
        {
            _services.AddScoped<IBookingRepository, BookingRepository>();
            _services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            _services.AddScoped<IRegionRepository, RegionRepository>();
            _services.AddScoped<ICategoryRepository, CategoryRepository>();
            _services.AddScoped<ITouristPointCategoryRepository, TouristPointCategoryRepository>();
            _services.AddScoped<ITouristPointRepository, TouristPointRepository>();
            _services.AddScoped<ILodgingRepository, LodgingRepository>();

            _services.AddScoped<IBookingService, BookingService>();
            _services.AddScoped<IAdministratorService, AdministratorService>();
            _services.AddScoped<ISessionService, SessionService>();
            _services.AddScoped<IRegionService, RegionService>();
            _services.AddScoped<ICategoryService, CategoryService>();
            _services.AddScoped<ITouristPointService, TouristPointService>();
            _services.AddScoped<ILodgingService, LodgingService>();
        }

        public void AddDbContextService()
        {
            _services.AddDbContext<DbContext, TourismContext>();
        }
    }
}
