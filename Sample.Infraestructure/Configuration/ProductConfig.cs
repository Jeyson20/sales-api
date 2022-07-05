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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(x => x.ProductName)
                   .IsUnique();
            builder.Property(x => x.UnitPrice)
                   .IsRequired()
                   .HasPrecision(18, 2);
            builder.Property(x => x.UnitsInStock)
                   .IsRequired();
            builder.Property(x => x.CreatedBy)
                    .HasMaxLength(30);
            builder.Property(x => x.ModifiedBy)
                  .HasMaxLength(30);
        }
    }
}
