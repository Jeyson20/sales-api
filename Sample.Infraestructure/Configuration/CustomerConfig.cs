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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                    .HasMaxLength(60)
                    .IsRequired();
            builder.Property(x => x.LastName)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(x => x.DocumentNumber)
                   .HasMaxLength(13)
                   .IsRequired();
            builder.Property(x => x.Address)
                  .HasMaxLength(60);

            builder.HasIndex("Email", "DocumentNumber", "PhoneNumber").IsUnique();

            builder.Property(x => x.Email)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(12)
                   .IsRequired();
            builder.Property(x => x.CreatedBy)
                  .HasMaxLength(30);
            builder.Property(x => x.ModifiedBy)
                  .HasMaxLength(30);
        }
    }
}
