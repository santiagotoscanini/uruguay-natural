using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    class TouristPointCategoryConfiguration : IEntityTypeConfiguration<TouristPointCategory>
    {
        public void Configure(EntityTypeBuilder<TouristPointCategory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(tc => tc.TouristPoint)
              .WithMany(t => t.TouristPointCategories);
            builder.HasOne(tc => tc.Category)
                .WithMany(c => c.CategoryTouristPoints);
        }
    }
}
