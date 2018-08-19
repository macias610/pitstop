using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    internal class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.ToTable("Engines");
            builder.Property(u => u.CreatedDate).HasColumnType("DateTime");
            builder.Property(u => u.ModifiedDate).HasColumnType("DateTime");
            builder.Property(u => u.Manufacturer).HasMaxLength(30);
            builder.Property(u => u.Version).IsRowVersion();
        }
    }
}
