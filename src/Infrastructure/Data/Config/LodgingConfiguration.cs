using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Infrastructure.Data.Config
{
    class LodgingConfiguration : IEntityTypeConfiguration<Lodging>
    {
        public void Configure(EntityTypeBuilder<Lodging> builder)
        {
            builder.Property(l => l.Images)
                .HasConversion(
                    i => JsonConvert.SerializeObject(i),
                    i => JsonConvert.DeserializeObject<IEnumerable<byte[]>>(i));
            builder.HasOne(l => l.TouristPoint).WithMany(tp => tp.Lodgings);
            builder.HasMany(l => l.Bookings).WithOne(b => b.Lodging).OnDelete(DeleteBehavior.Cascade);
        }
    }
}