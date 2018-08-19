using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(15);
            builder.Property(u => u.CreatedDate).HasColumnType("DateTime");
            builder.Property(u => u.ModifiedDate).HasColumnType("DateTime");
            builder.Property(u => u.BirthDate).HasColumnType("DateTime").IsRequired();
            builder.Property(u => u.Version).IsRowVersion();
        }
    }
}
