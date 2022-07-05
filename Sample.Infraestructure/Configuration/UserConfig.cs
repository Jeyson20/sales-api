using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infraestructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                    .HasMaxLength(60)
                    .IsRequired();
            builder.Property(x => x.LastName)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(x => x.Email)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(x => x.Rol)
                  .HasMaxLength(15)
                  .IsRequired();
            builder.Property(x => x.State)
                   .IsRequired();

            builder.HasIndex(x=>x.Email).IsUnique();

            builder.Property(x => x.Password)
                  .IsRequired();
            builder.Property(x => x.CreatedBy)
                  .HasMaxLength(30);
            builder.Property(x => x.ModifiedBy)
                  .HasMaxLength(30);
        }

    }
}
