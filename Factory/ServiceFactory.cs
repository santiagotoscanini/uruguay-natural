using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            _services.AddScoped<IRepository, Repository>();
            _services.AddScoped<IBookingService, BookingService>();
        }

        public void AddDbContextService()
        {
            _services.AddDbContext<DbContext, TourismContext>();
        }

    }
}
