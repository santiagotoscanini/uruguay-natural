using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    class TouristConfiguration : IEntityTypeConfiguration<Tourist>
    {
        public void Configure(EntityTypeBuilder<Tourist> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
