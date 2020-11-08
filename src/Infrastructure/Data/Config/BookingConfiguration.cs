using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Code);
            builder.HasOne(b => b.Lodging)
                .WithMany(l => l.Bookings).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
