using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    class TouristPointConfiguration : IEntityTypeConfiguration<TouristPoint>
    {
        public void Configure(EntityTypeBuilder<TouristPoint> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Region)
                .WithMany(c => c.TouristPoints);
        }
    }
}
