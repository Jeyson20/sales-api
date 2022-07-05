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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Categoryname)
                    .HasMaxLength(50)
                    .IsRequired();
            builder.HasIndex(t => t.Categoryname).IsUnique();

            builder.Property(x => x.Description)
                    .HasMaxLength(60);
            builder.Property(x => x.CreatedBy)
                    .HasMaxLength(30);
            builder.Property(x => x.ModifiedBy)
                  .HasMaxLength(30);
        }
    }
}
