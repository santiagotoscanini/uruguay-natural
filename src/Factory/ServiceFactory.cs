﻿using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
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
            _services.AddScoped<IBookingRepository, BookingRepository>();
            _services.AddScoped<IBookingService, BookingService>();
        }

        public void AddDbContextService()
        {
            _services.AddDbContext<DbContext, TourismContext>();
        }

    }
}
