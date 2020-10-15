using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Infrastructure.Data
{
    public class TourismContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<TouristPoint> TouristPoints { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        public TourismContext() {}

        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = configuration.GetConnectionString(@"TourismDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
