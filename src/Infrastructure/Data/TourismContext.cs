using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrastructure.Data
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }

        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public TourismContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string directory = Directory.GetCurrentDirectory();
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(directory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //        var connectionString = configuration.GetConnectionString(@"TourismDB");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}
